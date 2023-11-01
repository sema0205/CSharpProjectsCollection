using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    public User()
    {
        MessagesStatuses = new List<MessageStatus>();
    }

    public IList<MessageStatus> MessagesStatuses { get; }

    public void SendMessage(Message message)
    {
        MessagesStatuses.Add(new MessageStatus(message, false));
    }

    public UserReadMessageResult ReadMessage(Message message)
    {
        MessageStatus messageStatus = MessagesStatuses.Single(m => m.Message == message);

        if (messageStatus.Status)
            return new UserReadMessageResult.MessageWasAlreadyRead();

        MessagesStatuses.Remove(messageStatus);
        MessagesStatuses.Add(new MessageStatus(message, true));
        return new UserReadMessageResult.Success();
    }
}