namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

public abstract record ArgumentContext
{
    private ArgumentContext() { }

    public sealed record ConnectCommandContext(string Path, string Mode) : ArgumentContext;

    public sealed record TreeGoToCommandContext(string Path) : ArgumentContext;

    public sealed record TreeListCommandContext(int Depth) : ArgumentContext;

    public sealed record FileShowCommandContext(string Path, string Mode) : ArgumentContext;

    public sealed record FileMoveCommandContext(string SourcePath, string DestinationPath) : ArgumentContext;

    public sealed record FileCopyCommandContext(string SourcePath, string DestinationPath) : ArgumentContext;

    public sealed record FileDeleteCommandContext(string Path) : ArgumentContext;

    public sealed record FileRenameCommandContext(string Path, string NewName) : ArgumentContext;
}