using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Admins;

namespace Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly CurrentAdminManager _currentAdminManager;

    public AdminService(IAccountRepository accountRepository, IAdminRepository adminRepository, CurrentAdminManager currentAdminManager)
    {
        _accountRepository = accountRepository;
        _adminRepository = adminRepository;
        _currentAdminManager = currentAdminManager;
    }

    public async Task<LoginResult> LoginAsync(string login, string password)
    {
        Admin? admin = await _adminRepository.GetAdminByCredentialsAsync(login, password);

        if (admin is null)
            return new LoginResult.WrongCredentials();

        _currentAdminManager.Admin = admin;
        return new LoginResult.SuccessfulLogin();
    }

    public async Task<CreateResult> CreateAccountAsync(long cardNumber, string password)
    {
        Account? account = await _accountRepository.CreateAccountAsync(cardNumber, password);

        if (account is null)
            return new CreateResult.SomethingWentWrong();

        return new CreateResult.SuccessfulCreated();
    }
}