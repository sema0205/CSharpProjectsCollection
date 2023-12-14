using Lab5.Application.Models.Admins;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Admin?> CreateAdminAsync(string login, string password);

    Task<Admin?> GetAdminByCredentialsAsync(string login, string password);
}