using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;

public class GotoPathHandler : IArgumentHandler<TreeGoToBuilder>
{
    private IArgumentHandler<TreeGoToBuilder>? _next;

    public IArgumentHandler<TreeGoToBuilder> SetNextArgumentHandler(IArgumentHandler<TreeGoToBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult<TreeGoToBuilder> HandleArgumentRequest(ArgumentHandlerContext<TreeGoToBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithPath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult<TreeGoToBuilder>.Success(argumentHandlerContext.ContextBuilder);
    }
}