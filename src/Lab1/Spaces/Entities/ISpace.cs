using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public interface ISpace
{
    public int Distance { get; }

    public abstract IReadOnlyCollection<IObstacle?> GetObstacles();
}