using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class DisabledFileSystem : IFileSystem
{
    public CommandExecutionResult TreeList(int depth)
    {
        return new CommandExecutionResult.Failed();
    }

    public CommandExecutionResult FileShow(IPath path, IDrawer drawer)
    {
        return new CommandExecutionResult.Failed();
    }

    public CommandExecutionResult FileMove(IPath sourcePath, IPath destinationPath)
    {
        return new CommandExecutionResult.Failed();
    }

    public CommandExecutionResult FileCopy(IPath sourcePath, IPath destinationPath)
    {
        return new CommandExecutionResult.Failed();
    }

    public CommandExecutionResult FileDelete(IPath path)
    {
        return new CommandExecutionResult.Failed();
    }

    public CommandExecutionResult FileRename(IPath path, string newName)
    {
        return new CommandExecutionResult.Failed();
    }
}