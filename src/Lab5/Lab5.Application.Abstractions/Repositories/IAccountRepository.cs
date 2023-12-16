using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Task<Account?> CreateAccountAsync(long cardNumber, string password);

    Task<Account?> GetAccountByIdAsync(long accountId);

    Task<Account?> MakeOperationAsync(long accountId, decimal amount);

    Task<Account?> GetAccountByCredentialsAsync(long cardNumber, string password);
}