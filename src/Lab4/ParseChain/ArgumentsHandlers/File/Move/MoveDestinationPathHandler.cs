using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class MoveDestinationPathHandler : IArgumentHandler<FileMoveBuilder>
{
    private IArgumentHandler<FileMoveBuilder>? _next;

    public IArgumentHandler<FileMoveBuilder> SetNextArgumentHandler(IArgumentHandler<FileMoveBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return _next;
    }

    public ArgumentHandlerResult<FileMoveBuilder> HandleArgumentRequest(ArgumentHandlerContext<FileMoveBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithSourcePath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult<FileMoveBuilder>.Success(argumentHandlerContext.ContextBuilder);
    }
}