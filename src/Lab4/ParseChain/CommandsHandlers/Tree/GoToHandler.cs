using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Tree;

public class GoToHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;
    private IArgumentHandler<TreeGoToBuilder>? _nextArgumentHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "goto")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        if (_nextArgumentHandler is null)
            return new CommandHandlerResult.Failed();

        commandHandlerContext.CommandIterator.MoveNext();
        ArgumentHandlerResult<TreeGoToBuilder> builder = new ArgumentHandlerResult<TreeGoToBuilder>.Failed();
        while (commandHandlerContext.CommandIterator.HasMore())
        {
            builder = _nextArgumentHandler.HandleArgumentRequest(
                new ArgumentHandlerContext<TreeGoToBuilder>(commandHandlerContext.CommandIterator, new TreeGoToBuilder()));
        }

        if (builder is ArgumentHandlerResult<TreeGoToBuilder>.Success commandContext)
            return new CommandHandlerResult.Success(new GoToCommand(commandContext.Builder.Build()));

        return new CommandHandlerResult.Failed();
    }

    public ICommandHandler SetNextCommandHandler(ICommandHandler commandHandler)
    {
        if (_nextCommandHandler is null)
        {
            _nextCommandHandler = commandHandler;
            return _nextCommandHandler;
        }

        return _nextCommandHandler.SetNextCommandHandler(commandHandler);
    }

    public IArgumentHandler<TreeGoToBuilder> SetNextArgumentHandler(IArgumentHandler<TreeGoToBuilder> commandHandler)
    {
        if (_nextArgumentHandler is null)
        {
            _nextArgumentHandler = commandHandler;
            return commandHandler;
        }

        return _nextArgumentHandler.SetNextArgumentHandler(commandHandler);
    }
}