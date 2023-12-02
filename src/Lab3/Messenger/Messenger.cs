using Itmo.ObjectOrientedProgramming.Lab3.ConsoleWriter;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger
{
    private readonly IConsoleWriter _consoleWriter;

    public Messenger(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void PrintMessage(Message message)
    {
        _consoleWriter.Write(message.Title);
        _consoleWriter.Write(" ");
        _consoleWriter.Write(message.Body);
    }
}