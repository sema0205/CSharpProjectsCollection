namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public abstract record UserReadMessageResult
{
    private UserReadMessageResult() { }

    public sealed record Success : UserReadMessageResult;

    public sealed record MessageWasAlreadyRead : UserReadMessageResult;
}