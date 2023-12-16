using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public interface ILogger
{
    void LogMessage(Message message);
}