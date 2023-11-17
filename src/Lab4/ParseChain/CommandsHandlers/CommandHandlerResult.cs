using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain;

public abstract record CommandHandlerResult
{
    private CommandHandlerResult() { }

    public sealed record Success(IFileSystemCommand FileSystemCommand) : CommandHandlerResult;

    public sealed record ConnectCommand(ArgumentContext.ConnectCommandContext ConnectCommandContext) : CommandHandlerResult;

    public sealed record DisconnectCommand : CommandHandlerResult;

    public sealed record Failed : CommandHandlerResult;
}