using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class MoveCommand : IFileSystemCommand
{
    private IPath _sourcePath;
    private IPath _destinationPath;

    public MoveCommand(FileMoveCommandContext fileMoveCommandContext)
    {
        _sourcePath = new SimplePath(fileMoveCommandContext.SourcePath);
        _destinationPath = new SimplePath(fileMoveCommandContext.DestinationPath);
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        return commandExecutionContext.Service.FileMove(_sourcePath, _destinationPath);
    }
}