using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public abstract class Space
{
    public int Distance { get; protected set; }

    public abstract IReadOnlyCollection<IObstacle?> GetObstacles();
}