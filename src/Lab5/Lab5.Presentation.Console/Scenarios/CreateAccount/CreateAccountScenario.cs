using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create Account";

    public void Run()
    {
        long cardNumber = AnsiConsole.Ask<long>("Enter Card Number");
        string password = AnsiConsole.Ask<string>("Enter Password");

        CreateResult result = _adminService.CreateAccountAsync(cardNumber, password).Result;

        string message = result switch
        {
            CreateResult.SuccessfulCreated => "Successful Creation",
            CreateResult.SomethingWentWrong => "Account Was Not Created",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Console.Input.ReadKey(false);
    }
}