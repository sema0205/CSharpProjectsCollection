using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class GoToCommand : IFileSystemCommand
{
    private IPath _path;

    public GoToCommand(TreeGoToCommandContext treeGoToCommandContext)
    {
        _path = new SimplePath(treeGoToCommandContext.Path);
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        commandExecutionContext.CurrentPath = _path;
        return new CommandExecutionResult.Success();
    }
}