namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Tree;

public class TreeHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "tree")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        commandHandlerContext.CommandIterator.MoveNext();
        return _nextCommandHandler is not null
            ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
            : new CommandHandlerResult.Failed();
    }

    public ICommandHandler SetNextCommandHandler(ICommandHandler commandHandler)
    {
        if (_nextCommandHandler is null)
        {
            _nextCommandHandler = commandHandler;
            return commandHandler;
        }

        return _nextCommandHandler.SetNextCommandHandler(commandHandler);
    }
}