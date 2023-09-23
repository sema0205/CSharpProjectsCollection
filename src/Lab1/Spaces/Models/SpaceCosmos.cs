using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceCosmos : Space
{
    private readonly List<ObstacleCosmos?> _obstacles;

    public SpaceCosmos(IReadOnlyCollection<ObstacleCosmos?>? obstacles = null, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<ObstacleCosmos?>();
        if (obstacles == null) return;
        foreach (ObstacleCosmos? obstacle in obstacles)
        {
            for (int i = 0; i < obstacle?.ObstaclesAmount(); i++)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public override IReadOnlyCollection<ObstacleCosmos?> GetObstacles()
    {
        return _obstacles;
    }
}