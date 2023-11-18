using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;

public class ListDepthHandler : IArgumentHandler<TreeListBuilder>
{
    private IArgumentHandler<TreeListBuilder>? _next;

    public IArgumentHandler<TreeListBuilder> SetNextArgumentHandler(IArgumentHandler<TreeListBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return argumentHandler;
    }

    public ArgumentHandlerResult<TreeListBuilder> HandleArgumentRequest(ArgumentHandlerContext<TreeListBuilder> argumentHandlerContext)
    {
        if (argumentHandlerContext.CommandIterator.GetCurrent() != "-d")
        {
            return _next is not null ? _next.HandleArgumentRequest(argumentHandlerContext) : new ArgumentHandlerResult<TreeListBuilder>.Failed();
        }

        argumentHandlerContext.CommandIterator.MoveNext();

        bool result = int.TryParse(argumentHandlerContext.CommandIterator.GetCurrent(), out int depth);
        if (!result)
            return new ArgumentHandlerResult<TreeListBuilder>.Failed();

        argumentHandlerContext.ContextBuilder.WithDepth(depth);
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult<TreeListBuilder>.Success(argumentHandlerContext.ContextBuilder);
    }
}