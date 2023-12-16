using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain;

public abstract record CommandHandlerResult
{
    private CommandHandlerResult() { }

    public sealed record Success(IFileSystemCommand FileSystemCommand) : CommandHandlerResult;

    public sealed record Failed : CommandHandlerResult;
}