using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.Connection;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain;
using Itmo.ObjectOrientedProgramming.Lab4.Path;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestCases
{
    [Fact]
    public void TreeListCommandParseShouldBeCommandWithRightArguments()
    {
        var appContext = new CommandExecutionContext();
        IFileSystem mockFileSystem = Substitute.For<IFileSystem>();
        appContext.Service = mockFileSystem;

        var parser = new Parser.Parser();
        string someCommand = "tree list -d 3";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        if (handlerResult is CommandHandlerResult.Success handler)
            handler.FileSystemCommand.Execute(appContext);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is ListCommand);
        }

        mockFileSystem.Received().TreeList(3);
    }

    [Fact]
    public void ConnectCommandParseShouldBeCommandWithRightArguments()
    {
        var appContext = new CommandExecutionContext();
        var parser = new Parser.Parser();
        string someCommand = "connect /Folder/Some/ -m local";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        if (handlerResult is CommandHandlerResult.Success handler)
            handler.FileSystemCommand.Execute(appContext);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is ConnectCommand);
        }
    }

    [Fact]
    public void FileShowCommandParseShouldBeCommandWithRightArguments()
    {
        var appContext = new CommandExecutionContext();
        IFileSystem mockFileSystem = Substitute.For<IFileSystem>();
        appContext.Service = mockFileSystem;

        var parser = new Parser.Parser();
        string someCommand = "file show /SomeFolder/test.txt -m console";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        if (handlerResult is CommandHandlerResult.Success handler)
            handler.FileSystemCommand.Execute(appContext);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is ShowCommand);
        }

        mockFileSystem.Received().FileShow(Arg.Any<SimplePath>(), Arg.Any<ConsoleDrawer>());
    }

    [Fact]
    public void FileCopyCommandParseShouldBeCommandWithRightArguments()
    {
        var appContext = new CommandExecutionContext();
        IFileSystem mockFileSystem = Substitute.For<IFileSystem>();
        appContext.Service = mockFileSystem;

        var parser = new Parser.Parser();
        string someCommand = "file copy /SomeFolder/test.txt /AnotherFolder/SomethingHere";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        if (handlerResult is CommandHandlerResult.Success handler)
            handler.FileSystemCommand.Execute(appContext);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is CopyCommand);
        }

        mockFileSystem.Received().FileCopy(Arg.Any<SimplePath>(), Arg.Any<SimplePath>());
    }
}