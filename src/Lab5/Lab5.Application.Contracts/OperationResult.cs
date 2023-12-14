namespace Lab5.Application.Contracts.Accounts;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record SuccessfulOperation(decimal CurrentBalance) : OperationResult;

    public sealed record NotEnoughFunds : OperationResult;
}