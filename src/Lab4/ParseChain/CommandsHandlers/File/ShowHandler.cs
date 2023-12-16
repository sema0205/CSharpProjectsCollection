using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.File;

public class ShowHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;
    private IArgumentHandler<FileShowBuilder>? _nextArgumentHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "show")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        if (_nextArgumentHandler is null)
            return new CommandHandlerResult.Failed();

        commandHandlerContext.CommandIterator.MoveNext();
        ArgumentHandlerResult<FileShowBuilder> builder = new ArgumentHandlerResult<FileShowBuilder>.Failed();
        while (commandHandlerContext.CommandIterator.HasMore())
        {
            builder = _nextArgumentHandler.HandleArgumentRequest(
                new ArgumentHandlerContext<FileShowBuilder>(commandHandlerContext.CommandIterator, new FileShowBuilder()));
        }

        if (builder is ArgumentHandlerResult<FileShowBuilder>.Success commandContext)
            return new CommandHandlerResult.Success(new ShowCommand(commandContext.Builder.Build()));

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

    public IArgumentHandler<FileShowBuilder> SetNextArgumentHandler(IArgumentHandler<FileShowBuilder> commandHandler)
    {
        if (_nextArgumentHandler is null)
        {
            _nextArgumentHandler = commandHandler;
            return commandHandler;
        }

        return _nextArgumentHandler.SetNextArgumentHandler(commandHandler);
    }
}