using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class RenamePathHandler : IArgumentHandler<FileRenameBuilder>
{
    private IArgumentHandler<FileRenameBuilder>? _next;

    public IArgumentHandler<FileRenameBuilder> SetNextArgumentHandler(IArgumentHandler<FileRenameBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult<FileRenameBuilder> HandleArgumentRequest(ArgumentHandlerContext<FileRenameBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithPath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult<FileRenameBuilder>.Success(argumentHandlerContext.ContextBuilder);
    }
}