using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;

public class ShowCommand : IFileSystemCommand
{
    private IPath _path;
    private string _mode;

    public ShowCommand(FileShowCommandContext fileShowCommandContext)
    {
        _path = new SimplePath(fileShowCommandContext.Path);
        _mode = fileShowCommandContext.Mode;
    }

    public CommandExecutionResult Execute(CommandExecutionContext commandExecutionContext)
    {
        if (_mode == "console")
            return commandExecutionContext.Service.FileShow(_path, new ConsoleDrawer());

        return new CommandExecutionResult.Failed();
    }
}