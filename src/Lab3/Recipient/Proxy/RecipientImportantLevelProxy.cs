using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientImportantLevelProxy : IRecipient
{
    private readonly IRecipient _recipient;

    public RecipientImportantLevelProxy(IRecipient recipient)
    {
        _recipient = recipient;
    }

    public int ImportanceLevel { get; }

    public void SendMessage(Message message)
    {
        if (message.ImportanceLevel <= _recipient.ImportanceLevel)
        {
            _recipient.SendMessage(message);
        }
    }
}