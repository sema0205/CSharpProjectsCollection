using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsParseHandlers.ConnectionArguments;

public class AddressHandler : IArgumentHandler<ConnectBuilder>
{
    private IArgumentHandler<ConnectBuilder>? _next;

    public IArgumentHandler<ConnectBuilder> SetNextArgumentHandler(IArgumentHandler<ConnectBuilder> argumentHandler)
    {
        _next = argumentHandler;
        return _next;
    }

    public ArgumentHandlerResult<ConnectBuilder> HandleArgumentRequest(ArgumentHandlerContext<ConnectBuilder> argumentHandlerContext)
    {
        argumentHandlerContext.ContextBuilder.WithPath(argumentHandlerContext.CommandIterator.GetCurrent());
        argumentHandlerContext.CommandIterator.MoveNext();

        if (_next is not null && argumentHandlerContext.CommandIterator.HasMore())
            return _next.HandleArgumentRequest(argumentHandlerContext);

        return new ArgumentHandlerResult<ConnectBuilder>.Success(argumentHandlerContext.ContextBuilder);
    }
}