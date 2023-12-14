using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly CurrentAccountManager _currentAccountManager;

    public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository, CurrentAccountManager currentAccountService)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _currentAccountManager = currentAccountService;
    }

    public async Task<LoginResult> LoginAsync(long cardNumber, string password)
    {
        Account? account = await _accountRepository.GetAccountByCredentialsAsync(cardNumber, password);

        if (account is null)
            return new LoginResult.WrongCredentials();

        _currentAccountManager.Account = account;
        return new LoginResult.SuccessfulLogin();
    }

    public async Task<OperationResult> DepositAsync(decimal amount)
    {
        if (_currentAccountManager.Account is null)
            return new OperationResult.NotEnoughFunds();

        Account? account = await _accountRepository.MakeOperationAsync(_currentAccountManager.Account.CardNumber, amount);

        if (account is null)
            return new OperationResult.NotEnoughFunds();

        await _transactionRepository.CreateTransaction(amount, TransactionType.Deposit, _currentAccountManager.Account.CardNumber);
        return new OperationResult.SuccessfulOperation(account.Balance);
    }

    public async Task<OperationResult> WithdrawAsync(decimal amount)
    {
        if (_currentAccountManager.Account is null)
            return new OperationResult.NotEnoughFunds();

        Account? account = await _accountRepository.MakeOperationAsync(_currentAccountManager.Account.CardNumber, -amount);

        if (account is null)
            return new OperationResult.NotEnoughFunds();

        await _transactionRepository.CreateTransaction(amount, TransactionType.Withdrawal, _currentAccountManager.Account.CardNumber);
        return new OperationResult.SuccessfulOperation(account.Balance);
    }

    public async Task<BalanceResult> CheckBalanceAsync()
    {
        if (_currentAccountManager.Account is null)
            return new BalanceResult(0);

        Account? account = await _accountRepository.GetAccountByIdAsync(_currentAccountManager.Account.CardNumber);

        if (account is null)
            return new BalanceResult(0);

        return new BalanceResult(account.Balance);
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
        if (_currentAccountManager.Account is null)
            return Enumerable.Empty<Transaction>();

        Transaction[] transactions =
            await _transactionRepository.GetTransactionsByAccountIdAsync(_currentAccountManager.Account.CardNumber)
                .ToArrayAsync();

        if (transactions.Length == 0)
            return Enumerable.Empty<Transaction>();

        return transactions;
    }
}