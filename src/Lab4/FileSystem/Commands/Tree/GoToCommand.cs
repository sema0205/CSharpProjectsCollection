using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class GoToCommand : IFileSystemCommand
{
    private IPath _path;

    public GoToCommand(ArgumentContext.TreeGoToCommandContext treeGoToCommandContext)
    {
        _path = new SimplePath(treeGoToCommandContext.Path);
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.TreeGoTo(_path);
    }
}