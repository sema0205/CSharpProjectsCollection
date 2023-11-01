using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;

    public DisplayDriver(Color color)
    {
        _color = color;
    }

    public void ClearMessage()
    {
        Console.Clear();
    }

    public void ChangeColor(Color color)
    {
        _color = color;
    }

    public void ExportMessage(Message message)
    {
        Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message.Title);
        Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message.Body);
    }
}