using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientDisplay : IRecipient
{
    private readonly Display _display;

    public RecipientDisplay(Display display, int importanceLevel)
    {
        _display = display;
        ImportanceLevel = importanceLevel;
    }

    public int ImportanceLevel { get; }

    public void SendMessage(Message message)
    {
        _display.PrintMessage(message);
    }
}