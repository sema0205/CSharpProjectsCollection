using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly IRecipient _recipent;

    private string _name;

    public Topic(IRecipient recipent, string name)
    {
        _recipent = recipent;
        _name = name;
    }

    public void SendMessage(Message message)
    {
        _recipent.SendMessage(message);
    }
}