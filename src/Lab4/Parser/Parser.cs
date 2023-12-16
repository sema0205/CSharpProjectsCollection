using Itmo.ObjectOrientedProgramming.Lab4.ParseChain;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsParseHandlers.ConnectionArguments;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.CommandsParseHandlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.File;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class Parser
{
    private ICommandHandler _chain;

    public Parser()
    {
        // connect/disconnect handlers
        var connectHandler = new ConnectHandler();
        connectHandler.SetNextArgumentHandler(new AddressHandler()).SetNextArgumentHandler(new ModeHandler());

        var disconnectHandler = new DisconnectHandler();

        // tree handlers
        var goToHandler = new GoToHandler();
        goToHandler.SetNextArgumentHandler(new GotoPathHandler());

        var listHandler = new ListHandler();
        listHandler.SetNextArgumentHandler(new ListDepthHandler());
        goToHandler.SetNextCommandHandler(listHandler);

        ICommandHandler treeHandler = new TreeHandler(listHandler);

        // file handlers
        var showHandler = new ShowHandler();
        showHandler.SetNextArgumentHandler(new ShowPathHandler()).SetNextArgumentHandler(new ShowModeHandler());

        var moveHandler = new MoveHandler();
        moveHandler.SetNextArgumentHandler(new MoveSourcePathHandler()).SetNextArgumentHandler(new MoveDestinationPathHandler());

        var copyHandler = new CopyHandler();
        copyHandler.SetNextArgumentHandler(new CopySourcePathHandler()).SetNextArgumentHandler(new CopyDestinationPathHandler());

        var deleteHandler = new DeleteHandler();
        deleteHandler.SetNextArgumentHandler(new DeletePathHandler());

        var renameHandler = new RenameHandler();
        renameHandler.SetNextArgumentHandler(new RenamePathHandler()).SetNextArgumentHandler(new RenameNameHandler());
        showHandler
            .SetNextCommandHandler(moveHandler)
            .SetNextCommandHandler(copyHandler)
            .SetNextCommandHandler(deleteHandler)
            .SetNextCommandHandler(renameHandler);

        ICommandHandler fileHandler = new FileHandler(showHandler);

        _chain = connectHandler;
        _chain
            .SetNextCommandHandler(disconnectHandler)
            .SetNextCommandHandler(treeHandler)
            .SetNextCommandHandler(fileHandler);
    }

    public CommandHandlerResult Parse(string commandInput)
    {
        string[] test = commandInput.Split(" ");
        var iterator = new CommandIterator(test);
        return _chain.HandleCommandRequest(new CommandHandlerContext(iterator));
    }
}