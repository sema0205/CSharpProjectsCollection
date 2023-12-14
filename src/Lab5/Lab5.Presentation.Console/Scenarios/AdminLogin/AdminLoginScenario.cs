using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Lab5.Presentation.Console.Scenarios.CreateAccount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string login = AnsiConsole.Ask<string>("Enter your login");
        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = _adminService.LoginAsync(login, password).Result;

        if (result is LoginResult.SuccessfulLogin)
        {
            AnsiConsole.WriteLine("Successful login");

            AnsiConsole.Console.Input.ReadKey(false);
            AnsiConsole.Clear();

            SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
                .Title("Select Action")
                .AddChoices(new CreateAccountScenario(_adminService))
                .UseConverter(x => x.Name);

            IScenario scenario = AnsiConsole.Prompt(selector);
            scenario.Run();
        }

        if (result is LoginResult.WrongCredentials)
        {
            AnsiConsole.WriteLine("Wrong login or password");

            AnsiConsole.Console.Input.ReadKey(false);
            AnsiConsole.Clear();
        }

        AnsiConsole.Console.Input.ReadKey(false);
        AnsiConsole.Clear();
    }
}