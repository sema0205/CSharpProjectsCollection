using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestCases
{
    [Fact]
    public void WithdrawServiceMethodShouldSaveAccountWithUpdatedBalance()
    {
        IAccountRepository mockAccountRepository = Substitute.For<IAccountRepository>();
        ITransactionRepository mockTransactionRepository = Substitute.For<ITransactionRepository>();
        var currentAccountManager = new CurrentAccountManager();

        decimal startMoneyAmount = 1500;
        decimal withdrawMoneyAmount = 1000;
        decimal endMoneyAmount = 500;
        int accountId = 12345;
        currentAccountManager.Account = new Account(12345, startMoneyAmount, "password");

        mockAccountRepository.
            GetAccountByIdAsync(accountId).
            Returns(new Account(12345, startMoneyAmount, "password"));
        mockAccountRepository.
            MakeOperationAsync(12345, -withdrawMoneyAmount)
            .Returns(new Account(12345, startMoneyAmount - withdrawMoneyAmount, "password"));

        IAccountService accountService =
            new AccountService(mockAccountRepository, mockTransactionRepository, currentAccountManager);

        BalanceResult balanceResult = accountService.CheckBalanceAsync().Result;
        Assert.Equal(startMoneyAmount, balanceResult.Balance);

        OperationResult operationResult = accountService.WithdrawAsync(withdrawMoneyAmount).Result;
        Assert.True(operationResult is OperationResult.SuccessfulOperation);

        if (operationResult is OperationResult.SuccessfulOperation success)
            Assert.Equal(endMoneyAmount, success.CurrentBalance);
    }

    [Fact]
    public void WithdrawServiceMethodShouldReturnNotEnoughFundsError()
    {
        IAccountRepository mockAccountRepository = Substitute.For<IAccountRepository>();
        ITransactionRepository mockTransactionRepository = Substitute.For<ITransactionRepository>();
        var currentAccountManager = new CurrentAccountManager();

        decimal startMoneyAmount = 1500;
        decimal withdrawMoneyAmount = 2000;
        int accountId = 12345;
        currentAccountManager.Account = new Account(12345, startMoneyAmount, "password");

        mockAccountRepository.
            GetAccountByIdAsync(accountId).
            Returns(new Account(12345, startMoneyAmount, "password"));
        mockAccountRepository.MakeOperationAsync(12345, -withdrawMoneyAmount)
            .ReturnsNull();

        IAccountService accountService =
            new AccountService(mockAccountRepository, mockTransactionRepository, currentAccountManager);

        BalanceResult balanceResult = accountService.CheckBalanceAsync().Result;
        Assert.Equal(startMoneyAmount, balanceResult.Balance);

        OperationResult operationResult = accountService.WithdrawAsync(withdrawMoneyAmount).Result;
        Assert.True(operationResult is OperationResult.NotEnoughFunds);
    }

    [Fact]
    public void DepositServiceMethodShouldSaveAccountWithUpdatedBalance()
    {
        IAccountRepository mockAccountRepository = Substitute.For<IAccountRepository>();
        ITransactionRepository mockTransactionRepository = Substitute.For<ITransactionRepository>();
        var currentAccountManager = new CurrentAccountManager();

        decimal startMoneyAmount = 1500;
        decimal depositMoneyAmount = 2000;
        decimal endMoneyAmount = 3500;
        int accountId = 12345;
        currentAccountManager.Account = new Account(12345, startMoneyAmount, "password");

        mockAccountRepository.
            GetAccountByIdAsync(accountId).
            Returns(new Account(12345, startMoneyAmount, "password"));
        mockAccountRepository.MakeOperationAsync(12345, depositMoneyAmount)
            .Returns(new Account(12345, startMoneyAmount + depositMoneyAmount, "password"));

        IAccountService accountService =
            new AccountService(mockAccountRepository, mockTransactionRepository, currentAccountManager);

        BalanceResult balanceResult = accountService.CheckBalanceAsync().Result;
        Assert.Equal(startMoneyAmount, balanceResult.Balance);

        OperationResult operationResult = accountService.DepositAsync(depositMoneyAmount).Result;
        Assert.True(operationResult is OperationResult.SuccessfulOperation);
        if (operationResult is OperationResult.SuccessfulOperation success)
            Assert.Equal(endMoneyAmount, success.CurrentBalance);
    }
}