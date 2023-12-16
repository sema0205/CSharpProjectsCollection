namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain;

public interface ICommandHandler
{
    ICommandHandler SetNextCommandHandler(ICommandHandler commandHandler);

    CommandHandlerResult HandleCommandRequest(CommandHandlerContext commandHandlerContext);
}