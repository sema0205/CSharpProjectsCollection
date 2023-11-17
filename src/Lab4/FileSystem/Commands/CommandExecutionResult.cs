namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public abstract record CommandExecutionResult
{
    private CommandExecutionResult() { }

    public sealed record Success : CommandExecutionResult;

    public sealed record Failed : CommandExecutionResult;
}