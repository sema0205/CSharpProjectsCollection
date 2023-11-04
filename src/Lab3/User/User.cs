using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    private readonly List<MessageStatus> _messagesStatuses;

    public User()
    {
        _messagesStatuses = new List<MessageStatus>();
    }

    public IReadOnlyCollection<MessageStatus> MessagesStatuses => _messagesStatuses;

    public void SendMessage(Message message)
    {
        _messagesStatuses.Add(new MessageStatus(message, false));
    }

    public UserReadMessageResult ReadMessage(Message message)
    {
        MessageStatus messageStatus = _messagesStatuses.Single(m => m.Message == message);

        if (messageStatus.Status)
            return new UserReadMessageResult.MessageWasAlreadyRead();

        _messagesStatuses.Remove(messageStatus);
        _messagesStatuses.Add(new MessageStatus(message, true));
        return new UserReadMessageResult.Success();
    }
}