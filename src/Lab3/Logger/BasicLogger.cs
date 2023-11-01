using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class BasicLogger : ILogger
{
    private List<Message> _messages;

    public BasicLogger()
    {
        _messages = new List<Message>();
    }

    public void LogMessage(Message message)
    {
        _messages.Add(message);
    }
}