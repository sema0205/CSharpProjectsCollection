using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.Scenarios.Account;

namespace Lab5.Presentation.Console.Scenarios.AccountLogin;

public class AccountLoginScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentAccountService _currentAccount;

    public AccountLoginScenarioProvider(IAccountService accountService, ICurrentAccountService currentAccount)
    {
        _accountService = accountService;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Account is not null)
        {
            scenario = new AccountScenariosGroup(_accountService);
            return true;
        }

        scenario = new AccountLoginScenario(_accountService);
        return true;
    }
}