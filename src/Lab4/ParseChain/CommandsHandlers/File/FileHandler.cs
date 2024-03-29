namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.File;

public class FileHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;
    private ICommandHandler? _nextFileCommandHandler;

    public FileHandler(ICommandHandler nextFileCommandHandler)
    {
        _nextFileCommandHandler = nextFileCommandHandler;
    }

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "file")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        commandHandlerContext.CommandIterator.MoveNext();
        return _nextFileCommandHandler is not null
            ? _nextFileCommandHandler.HandleCommandRequest(commandHandlerContext)
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