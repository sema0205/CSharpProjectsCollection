using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw Money";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter Money Amount");

        OperationResult result = _accountService.WithdrawAsync(amount).Result;

        switch (result)
        {
            case OperationResult.SuccessfulOperation success:
                AnsiConsole.WriteLine("Successful Withdrawal");
                AnsiConsole.WriteLine($"Your Current Balance is {success.CurrentBalance} $");
                AnsiConsole.Console.Input.ReadKey(false);
                return;
            case OperationResult.NotEnoughFunds:
                AnsiConsole.WriteLine("Not Enough Funds On Your Account");
                AnsiConsole.Console.Input.ReadKey(false);
                return;
            default:
                AnsiConsole.WriteLine("Something Went Wrong");
                AnsiConsole.Console.Input.ReadKey(false);
                break;
        }
    }
}