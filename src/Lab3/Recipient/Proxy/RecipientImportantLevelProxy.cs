using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientImportantLevelProxy : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly int _importanceLevel;

    public RecipientImportantLevelProxy(IRecipient recipient, int importanceLevel)
    {
        _recipient = recipient;
        _importanceLevel = importanceLevel;
    }

    public void SendMessage(Message message)
    {
        if (message.ImportanceLevel <= _importanceLevel)
        {
            _recipient.SendMessage(message);
        }
    }
}