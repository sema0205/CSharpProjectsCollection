namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain;

public record ArgumentHandlerResult
{
    private ArgumentHandlerResult() { }

    public sealed record Success<T>(T Builder) : ArgumentHandlerResult;

    public sealed record Failed : ArgumentHandlerResult;
}