namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.Connection;

public class DisconnectCommand : IFileSystemCommand
{
    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        commandExecutionContext.Service = new DisabledFileSystem();
        return new CommandExecutionResult.Success();
    }
}