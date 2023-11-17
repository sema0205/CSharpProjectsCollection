using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class MoveSourcePathHandler : IArgumentHandler<FileMoveBuilder>
{
    private IArgumentHandler<FileMoveBuilder>? _next;

    public IArgumentHandler<FileMoveBuilder> SetNextArgumentHandler(IArgumentHandler<FileMoveBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult HandleArgumentRequest(ArgumentHandlerContext<FileMoveBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithSourcePath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult.Success<FileMoveBuilder>(argumentHandlerContext.ContextBuilder);
    }
}