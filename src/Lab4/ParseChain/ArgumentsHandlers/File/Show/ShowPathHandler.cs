using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class ShowPathHandler : IArgumentHandler<FileShowBuilder>
{
    private IArgumentHandler<FileShowBuilder>? _next;

    public IArgumentHandler<FileShowBuilder> SetNextArgumentHandler(IArgumentHandler<FileShowBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult HandleArgumentRequest(ArgumentHandlerContext<FileShowBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithPath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult.Success<FileShowBuilder>(argumentHandlerContext.ContextBuilder);
    }
}