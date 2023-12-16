using Lab5.Application.Contracts.Admins;
using Lab5.Presentation.Console.Scenarios.CreateAccount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Account;

public class AdminScenariosGroup : IScenario
{
    private readonly IAdminService _adminService;

    public AdminScenariosGroup(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select Action")
            .AddChoices(new CreateAccountScenario(_adminService))
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }
}