using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class ShowModeHandler : IArgumentHandler<FileShowBuilder>
{
    private IArgumentHandler<FileShowBuilder>? _next;

    public IArgumentHandler<FileShowBuilder> SetNextArgumentHandler(IArgumentHandler<FileShowBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult HandleArgumentRequest(ArgumentHandlerContext<FileShowBuilder> argumentHandlerContext)
    {
        if (argumentHandlerContext.CommandIterator.GetCurrent() != "-m")
        {
            return _next is not null ? _next.HandleArgumentRequest(argumentHandlerContext) : new ArgumentHandlerResult.Failed();
        }

        argumentHandlerContext.CommandIterator.MoveNext();
        argumentHandlerContext.ContextBuilder.WithMode(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult.Success<FileShowBuilder>(argumentHandlerContext.ContextBuilder);
    }
}