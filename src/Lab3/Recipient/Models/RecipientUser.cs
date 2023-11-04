using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientUser : IRecipient
{
    private readonly User _user;

    public RecipientUser(User user)
    {
        _user = user;
    }

    public void SendMessage(Message message)
    {
        _user.SendMessage(message);
    }
}