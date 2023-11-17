using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.File;

public class CopyHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;
    private IArgumentHandler<FileCopyBuilder>? _nextArgumentHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "copy")
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
                new ArgumentHandlerContext<FileCopyBuilder>(commandHandlerContext.CommandIterator, new FileCopyBuilder()));
        }

        if (builder is ArgumentHandlerResult.Success<FileCopyBuilder> commandContext)
            return new CommandHandlerResult.Success(new CopyCommand(commandContext.Builder.Build()));

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

    public IArgumentHandler<FileCopyBuilder> SetNextArgumentHandler(IArgumentHandler<FileCopyBuilder> commandHandler)
    {
        if (_nextArgumentHandler is null)
        {
            _nextArgumentHandler = commandHandler;
            return commandHandler;
        }

        return _nextArgumentHandler.SetNextArgumentHandler(commandHandler);
    }
}