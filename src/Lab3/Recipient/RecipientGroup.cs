using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientGroup : IRecipient
{
    private readonly IReadOnlyList<IRecipient> _recipients;

    public RecipientGroup(IEnumerable<IRecipient> recipients, int importanceLevel)
    {
        _recipients = recipients.ToList();
        ImportanceLevel = importanceLevel;
    }

    public int ImportanceLevel { get; }

    public void SendMessage(Message message)
    {
        _recipients
            .ToList()
            .ForEach(recipient => recipient.SendMessage(message));
    }
}