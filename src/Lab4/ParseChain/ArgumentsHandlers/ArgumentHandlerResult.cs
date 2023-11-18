namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain;

public record ArgumentHandlerResult<T>
{
    private ArgumentHandlerResult() { }

    public sealed record Success(T Builder) : ArgumentHandlerResult<T>;

    public sealed record Failed : ArgumentHandlerResult<T>;
}