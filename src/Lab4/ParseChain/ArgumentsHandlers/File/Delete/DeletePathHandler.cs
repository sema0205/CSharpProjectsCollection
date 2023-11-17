using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class DeletePathHandler : IArgumentHandler<FileDeleteBuilder>
{
    private IArgumentHandler<FileDeleteBuilder>? _next;

    public IArgumentHandler<FileDeleteBuilder> SetNextArgumentHandler(IArgumentHandler<FileDeleteBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult HandleArgumentRequest(ArgumentHandlerContext<FileDeleteBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithPath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult.Success<FileDeleteBuilder>(argumentHandlerContext.ContextBuilder);
    }
}