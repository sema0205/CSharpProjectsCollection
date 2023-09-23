using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceNebulaDensity : Space
{
    private readonly List<ObstacleNebulaDensity?> _obstacles;

    public SpaceNebulaDensity(IReadOnlyCollection<ObstacleNebulaDensity?>? obstacles = null, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<ObstacleNebulaDensity?>();
        if (obstacles == null) return;
        foreach (ObstacleNebulaDensity? obstacle in obstacles)
        {
            for (int i = 0; i < obstacle?.ObstaclesAmount(); i++)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public override IReadOnlyCollection<ObstacleNebulaDensity?> GetObstacles()
    {
        return _obstacles;
    }
}