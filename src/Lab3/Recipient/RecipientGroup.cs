using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientGroup : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public RecipientGroup(IEnumerable<IRecipient> recipients)
    {
        _recipients = recipients.ToList();
    }

    public void SendMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.SendMessage(message);
        }
    }
}