using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class CopyCommand : IFileSystemCommand
{
    private IPath _sourcePath;
    private IPath _destinationPath;

    public CopyCommand(ArgumentContext.FileCopyCommandContext fileCopyCommandContext)
    {
        _sourcePath = new SimplePath(fileCopyCommandContext.SourcePath);
        _destinationPath = new SimplePath(fileCopyCommandContext.DestinationPath);
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.FileCopy(_sourcePath, _destinationPath);
    }
}