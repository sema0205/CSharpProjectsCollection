using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class ConsoleDrawer : IDrawer
{
    public void Draw(string info)
    {
        Console.WriteLine(info);
    }
}