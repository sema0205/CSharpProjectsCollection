using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Tree;

public class ListHandler : ICommandHandler
{
    private ICommandHandler? _nextCommandHandler;
    private IArgumentHandler<TreeListBuilder>? _nextArgumentHandler;

    public CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext)
    {
        if (commandHandlerContext.CommandIterator.GetCurrent() != "list")
        {
            return _nextCommandHandler is not null
                ? _nextCommandHandler.HandleCommandRequest(commandHandlerContext)
                : new CommandHandlerResult.Failed();
        }

        if (_nextArgumentHandler is null)
            return new CommandHandlerResult.Failed();

        commandHandlerContext.CommandIterator.MoveNext();
        ArgumentHandlerResult builder = new ArgumentHandlerResult.Success<TreeListBuilder>(new TreeListBuilder());
        while (commandHandlerContext.CommandIterator.HasMore())
        {
            builder = _nextArgumentHandler.HandleArgumentRequest(
                new ArgumentHandlerContext<TreeListBuilder>(commandHandlerContext.CommandIterator, new TreeListBuilder()));
        }

        if (builder is ArgumentHandlerResult.Success<TreeListBuilder> commandContext)
            return new CommandHandlerResult.Success(new ListCommand(commandContext.Builder.Build()));

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

    public IArgumentHandler<TreeListBuilder> SetNextArgumentHandler(IArgumentHandler<TreeListBuilder> commandHandler)
    {
        if (_nextArgumentHandler is null)
        {
            _nextArgumentHandler = commandHandler;
            return commandHandler;
        }

        return _nextArgumentHandler.SetNextArgumentHandler(commandHandler);
    }
}