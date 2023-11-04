using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientDisplay : IRecipient
{
    private readonly Display _display;

    public RecipientDisplay(Display display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        _display.PrintMessage(message);
    }
}