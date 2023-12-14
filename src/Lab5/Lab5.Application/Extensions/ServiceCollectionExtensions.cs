using Lab5.Application.Accounts;
using Lab5.Application.Admins;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        collection.AddScoped<CurrentAdminManager>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminManager>());

        return collection;
    }
}