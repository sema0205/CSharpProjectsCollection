using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceCosmos : ISpace
{
    private readonly List<IObstacleCosmos> _obstacles;

    public SpaceCosmos(IReadOnlyCollection<IObstacleCosmos>? obstacles = null, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<IObstacleCosmos>();
        if (obstacles == null) return;
        foreach (IObstacleCosmos obstacle in obstacles)
        {
            for (int i = 0; i < obstacle.ObstaclesAmount(); i++)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public int Distance { get; }

    public IReadOnlyCollection<IObstacle> GetObstacles()
    {
        return _obstacles;
    }
}