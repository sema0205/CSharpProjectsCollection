using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit Money";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter Money Amount");

        OperationResult result = _accountService.DepositAsync(amount).Result;

        switch (result)
        {
            case OperationResult.SuccessfulOperation success:
                AnsiConsole.WriteLine("Successful Deposit");
                AnsiConsole.WriteLine($"Your Current Balance is {success.CurrentBalance} $");
                AnsiConsole.Console.Input.ReadKey(false);
                return;
            default:
                AnsiConsole.WriteLine("Something Went Wrong");
                AnsiConsole.Console.Input.ReadKey(false);
                break;
        }
    }
}