using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class ListCommand : IFileSystemCommand
{
    private int _depth;

    public ListCommand(TreeListCommandContext treeListCommandContext)
    {
        _depth = treeListCommandContext.Depth;
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.TreeList(_depth);
    }
}