namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public interface IFileSystemCommand
{
    CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext);
}