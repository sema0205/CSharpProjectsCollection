using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowBalance;

public class ShowBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public ShowBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Show Balance";

    public void Run()
    {
        BalanceResult result = _accountService.CheckBalanceAsync().Result;

        AnsiConsole.WriteLine($"You got {result.Balance}$ on your account");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}