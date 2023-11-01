using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientMessenger : IRecipient
{
    private readonly Messenger _messenger;

    public RecipientMessenger(Messenger messenger, int importanceLevel)
    {
        _messenger = messenger;
        ImportanceLevel = importanceLevel;
    }

    public int ImportanceLevel { get; }

    public void SendMessage(Message message)
    {
        _messenger.PrintMessage(message);
    }
}