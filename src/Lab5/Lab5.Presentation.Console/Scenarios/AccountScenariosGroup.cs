using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.Scenarios.DepositMoney;
using Lab5.Presentation.Console.Scenarios.ShowBalance;
using Lab5.Presentation.Console.Scenarios.ShowTransactionsHistory;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Account;

public class AccountScenariosGroup : IScenario
{
    private readonly IAccountService _accountService;

    public AccountScenariosGroup(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Account Login";

    public void Run()
    {
        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select Action")
            .AddChoices(new ShowBalanceScenario(_accountService))
            .AddChoices(new WithdrawMoneyScenario(_accountService))
            .AddChoices(new DepositMoneyScenario(_accountService))
            .AddChoices(new ShowTransactionHistoryScenario(_accountService))
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }
}