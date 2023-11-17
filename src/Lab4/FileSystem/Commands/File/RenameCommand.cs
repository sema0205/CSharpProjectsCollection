using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class RenameCommand : IFileSystemCommand
{
    private IPath _path;
    private string _newName;

    public RenameCommand(ArgumentContext.FileRenameCommandContext fileRenameCommandContext)
    {
        _path = new SimplePath(fileRenameCommandContext.Path);
        _newName = fileRenameCommandContext.NewName;
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.FileRename(_path, _newName);
    }
}