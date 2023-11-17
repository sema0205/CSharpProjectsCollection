using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class ListCommand : IFileSystemCommand
{
    private int _depth;

    public ListCommand(ArgumentContext.TreeListCommandContext treeListCommandContext)
    {
        _depth = treeListCommandContext.Depth;
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.TreeList(_depth);
    }
}