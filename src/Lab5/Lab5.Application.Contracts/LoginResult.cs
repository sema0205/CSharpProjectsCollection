namespace Lab5.Application.Contracts.Accounts;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record SuccessfulLogin : LoginResult;

    public sealed record WrongCredentials : LoginResult;
}