using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    Task<LoginResult> LoginAsync(long cardNumber, string password);

    Task<OperationResult> DepositAsync(decimal amount);

    Task<OperationResult> WithdrawAsync(decimal amount);

    Task<BalanceResult> CheckBalanceAsync();

    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
}