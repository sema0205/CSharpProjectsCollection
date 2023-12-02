using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientMessenger : IRecipient
{
    private readonly Messenger _messenger;

    public RecipientMessenger(Messenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        _messenger.PrintMessage(message);
    }
}