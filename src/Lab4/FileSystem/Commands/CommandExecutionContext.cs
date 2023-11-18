using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class CommandExecutionContext
{
    public CommandExecutionContext()
    {
        Service = new DisabledFileSystem();
        CurrentPath = new DisabledPath();
    }

    public IFileSystem Service { get; set; }

    public IPath CurrentPath { get; set; }
}