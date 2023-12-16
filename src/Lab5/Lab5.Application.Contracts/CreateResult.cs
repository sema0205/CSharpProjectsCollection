namespace Lab5.Application.Contracts.Accounts;

public abstract record CreateResult
{
    private CreateResult() { }

    public sealed record SuccessfulCreated : CreateResult;

    public sealed record SomethingWentWrong : CreateResult;
}