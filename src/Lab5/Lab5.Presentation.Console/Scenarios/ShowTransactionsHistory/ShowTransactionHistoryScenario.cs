using Lab5.Application.Contracts.Accounts;
using Spectre.Console;
using Transaction = Lab5.Application.Models.Transactions.Transaction;

namespace Lab5.Presentation.Console.Scenarios.ShowTransactionsHistory;

public class ShowTransactionHistoryScenario : IScenario
{
    private readonly IAccountService _accountService;

    public ShowTransactionHistoryScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Show All Transactions";

    public void Run()
    {
        IEnumerable<Transaction> transactions = _accountService.GetAllTransactionsAsync().Result;

        AnsiConsole.WriteLine("Here is all transactions on your account");

        foreach (Transaction transaction in transactions)
        {
            AnsiConsole.WriteLine($"{transaction.Type} transaction on {transaction.Amount} $");
        }

        AnsiConsole.Console.Input.ReadKey(false);
    }
}