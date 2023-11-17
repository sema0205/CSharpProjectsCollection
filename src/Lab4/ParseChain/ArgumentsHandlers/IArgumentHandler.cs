namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;

public interface IArgumentHandler<T>
{
    IArgumentHandler<T> SetNextArgumentHandler(IArgumentHandler<T> argumentHandler);

    ArgumentHandlerResult HandleArgumentRequest(ArgumentHandlerContext<T> argumentHandlerContext);
}