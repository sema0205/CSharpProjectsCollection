using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AccountLogin;

public class AccountLoginScenario : IScenario
{
    private readonly IAccountService _accountService;

    public AccountLoginScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Account Login";

    public void Run()
    {
        long cardNumber = AnsiConsole.Ask<long>("Enter Your Card Number");
        string password = AnsiConsole.Ask<string>("Enter Your Password");

        LoginResult result = _accountService.LoginAsync(cardNumber, password).Result;

        if (result is LoginResult.SuccessfulLogin)
        {
            AnsiConsole.WriteLine("Successful login");

            AnsiConsole.Console.Input.ReadKey(false);
            AnsiConsole.Clear();
            return;
        }

        if (result is LoginResult.WrongCredentials)
            AnsiConsole.WriteLine("Wrong login or password");

        AnsiConsole.Console.Input.ReadKey(false);
        AnsiConsole.Clear();
    }
}