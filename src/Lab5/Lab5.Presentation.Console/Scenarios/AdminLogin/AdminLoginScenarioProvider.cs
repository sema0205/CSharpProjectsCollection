using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Admins;
using Lab5.Presentation.Console.Scenarios.Account;

namespace Lab5.Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;

    public AdminLoginScenarioProvider(IAdminService adminService, ICurrentAdminService currentAdmin)
    {
        _adminService = adminService;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            scenario = new AdminScenariosGroup(_adminService);
            return true;
        }

        scenario = new AdminLoginScenario(_adminService);
        return true;
    }
}