using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

public class CopyDestinationPathHandler : IArgumentHandler<FileCopyBuilder>
{
    private IArgumentHandler<FileCopyBuilder>? _next;

    public IArgumentHandler<FileCopyBuilder> SetNextArgumentHandler(IArgumentHandler<FileCopyBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult<FileCopyBuilder> HandleArgumentRequest(ArgumentHandlerContext<FileCopyBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithDestinationPath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult<FileCopyBuilder>.Success(argumentHandlerContext.ContextBuilder);
    }
}