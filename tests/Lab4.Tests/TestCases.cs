using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestCases
{
    [Fact]
    public void TreeListCommandParseShouldBeCommandWithRightArguments()
    {
        var parser = new Parser.Parser();
        string someCommand = "tree list -d 3";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        FileSystemCallHandler handler = Substitute.For<FileSystemCallHandler>();

        handler.CallFileSystem(handlerResult);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is ListCommand);
        }

        handler.Received().CallFileSystem(handlerResult);
    }

    [Fact]
    public void ConnectCommandParseShouldBeCommandWithRightArguments()
    {
        var parser = new Parser.Parser();
        string someCommand = "connect /Folder/Some/ -m local";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        FileSystemCallHandler handler = Substitute.For<FileSystemCallHandler>();

        handler.CallFileSystem(handlerResult);

        Assert.True(handlerResult is CommandHandlerResult.ConnectCommand);
        if (handlerResult is CommandHandlerResult.ConnectCommand command)
        {
            Assert.True(command.ConnectCommandContext is ArgumentContext.ConnectCommandContext);
        }

        handler.Received().CallFileSystem(handlerResult);
    }

    [Fact]
    public void FileShowCommandParseShouldBeCommandWithRightArguments()
    {
        var parser = new Parser.Parser();
        string someCommand = "file show /SomeFolder/test.txt -m console";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        FileSystemCallHandler handler = Substitute.For<FileSystemCallHandler>();

        handler.CallFileSystem(handlerResult);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is ShowCommand);
        }

        handler.Received().CallFileSystem(handlerResult);
    }

    [Fact]
    public void FileCopyCommandParseShouldBeCommandWithRightArguments()
    {
        var parser = new Parser.Parser();
        string someCommand = "file show /SomeFolder/test.txt /AnotherFolder/SomethingHere";

        CommandHandlerResult handlerResult = parser.Parse(someCommand);
        FileSystemCallHandler handler = Substitute.For<FileSystemCallHandler>();

        handler.CallFileSystem(handlerResult);

        Assert.True(handlerResult is CommandHandlerResult.Success);
        if (handlerResult is CommandHandlerResult.Success command)
        {
            Assert.True(command.FileSystemCommand is ShowCommand);
        }

        handler.Received().CallFileSystem(handlerResult);
    }
}