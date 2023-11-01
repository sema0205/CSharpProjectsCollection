using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Logger;

public class RecipientLogger : IRecipient
{
    private readonly ILogger _logger;
    private readonly IRecipient _recipient;

    public RecipientLogger(ILogger logger, IRecipient recipient)
    {
        _logger = logger;
        _recipient = recipient;
        ImportanceLevel = _recipient.ImportanceLevel;
    }

    public int ImportanceLevel { get; }

    public void SendMessage(Message message)
    {
        _recipient.SendMessage(message);
        _logger.LogMessage(message);
    }
}