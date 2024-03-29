using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class DeleteCommand : IFileSystemCommand
{
    private IPath _path;

    public DeleteCommand(FileDeleteCommandContext fileDeleteCommandContext)
    {
        _path = new SimplePath(fileDeleteCommandContext.Path);
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.FileDelete(_path);
    }
}