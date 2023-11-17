using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.File;

public class DeleteHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;
    private IArgumentHandler<FileDeleteBuilder>? _nextArgumentHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "delete")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        if (_nextArgumentHandler is null)
            return new CommandHandlerResult.Failed();

        commandHandlerContext.CommandIterator.MoveNext();
        ArgumentHandlerResult builder = new ArgumentHandlerResult.Failed();
        while (commandHandlerContext.CommandIterator.HasMore())
        {
            builder = _nextArgumentHandler.HandleArgumentRequest(
                new ArgumentHandlerContext<FileDeleteBuilder>(commandHandlerContext.CommandIterator, new FileDeleteBuilder()));
        }

        if (builder is ArgumentHandlerResult.Success<FileDeleteBuilder> commandContext)
            return new CommandHandlerResult.Success(new DeleteCommand(commandContext.Builder.Build()));

        return new CommandHandlerResult.Failed();
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

    public IArgumentHandler<FileDeleteBuilder> SetNextArgumentHandler(IArgumentHandler<FileDeleteBuilder> commandHandler)
    {
        if (_nextArgumentHandler is null)
        {
            _nextArgumentHandler = commandHandler;
            return commandHandler;
        }

        return _nextArgumentHandler.SetNextArgumentHandler(commandHandler);
    }
}