using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    CommandExecutionResult TreeGoTo(IPath path);

    CommandExecutionResult TreeList(int depth);

    CommandExecutionResult FileShow(IPath path, string mode);

    CommandExecutionResult FileMove(IPath sourcePath, IPath destinationPath);

    CommandExecutionResult FileCopy(IPath sourcePath, IPath destinationPath);

    CommandExecutionResult FileDelete(IPath path);

    CommandExecutionResult FileRename(IPath path, string newName);
}