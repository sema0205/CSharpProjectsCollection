using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    void ClearMessage();

    void ChangeColor(Color color);

    void ExportMessage(Message message);
}