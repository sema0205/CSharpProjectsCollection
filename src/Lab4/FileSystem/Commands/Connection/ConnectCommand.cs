using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsParseHandlers.ConnectionArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.Connection;

public class ConnectCommand : IFileSystemCommand
{
    private IPath _path;
    private string _mode;

    public ConnectCommand(ConnectCommandContext connectCommandContext)
    {
        _path = new SimplePath(connectCommandContext.Path);
        _mode = connectCommandContext.Mode;
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        commandExecutionContext.Service = new FileSystem(_path, _mode);
        return new CommandExecutionResult.Success();
    }
}