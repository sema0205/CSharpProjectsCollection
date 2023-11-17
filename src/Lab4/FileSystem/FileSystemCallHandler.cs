using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileSystemCallHandler
{
    private FileSystem? _fileSystem;

    public CommandExecutionResult CallFileSystem(CommandHandlerResult commandHandlerResult)
    {
        if (commandHandlerResult is CommandHandlerResult.Failed)
            return new CommandExecutionResult.Failed();

        if (commandHandlerResult is CommandHandlerResult.ConnectCommand connectCommand)
        {
            _fileSystem = new FileSystem(
                new SimplePath(connectCommand.ConnectCommandContext.Path),
                connectCommand.ConnectCommandContext.Mode);
            return new CommandExecutionResult.Success();
        }

        if (commandHandlerResult is CommandHandlerResult.DisconnectCommand)
        {
            _fileSystem = null;
            return new CommandExecutionResult.Failed();
        }

        if (commandHandlerResult is CommandHandlerResult.Success command)
        {
            if (_fileSystem is not null)
                return command.FileSystemCommand.Execute(new CommandExecutionContext(_fileSystem));
        }

        return new CommandExecutionResult.Failed();
    }
}