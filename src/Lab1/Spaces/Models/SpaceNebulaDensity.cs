using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceNebulaDensity : ISpace
{
    private readonly List<IObstacleNebulaDensity> _obstacles;

    public SpaceNebulaDensity(IReadOnlyCollection<IObstacleNebulaDensity>? obstacles = null, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<IObstacleNebulaDensity>();
        if (obstacles == null) return;
        foreach (IObstacleNebulaDensity obstacle in obstacles)
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