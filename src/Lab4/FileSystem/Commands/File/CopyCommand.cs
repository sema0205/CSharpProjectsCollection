using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class CopyCommand : IFileSystemCommand
{
    private IPath _sourcePath;
    private IPath _destinationPath;

    public CopyCommand(FileCopyCommandContext fileCopyCommandContext)
    {
        _sourcePath = new SimplePath(fileCopyCommandContext.SourcePath);
        _destinationPath = new SimplePath(fileCopyCommandContext.DestinationPath);
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.FileCopy(_sourcePath, _destinationPath);
    }
}