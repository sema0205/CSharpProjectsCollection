using Lab5.Application.Contracts.Accounts;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminService
{
    Task<LoginResult> LoginAsync(string login, string password);

    Task<CreateResult> CreateAccountAsync(long cardNumber, string password);
}