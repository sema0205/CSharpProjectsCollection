using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.CommandsParseHandlers.ConnectionCommands;

public class DisconnectHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "disconnect")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        return new CommandHandlerResult.Success(new DisconnectCommand());
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