using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceNebulaParticles : Space
{
    private readonly List<ObstacleNebulaParticles?> _obstacles;

    public SpaceNebulaParticles(IReadOnlyCollection<ObstacleNebulaParticles?>? obstacles, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<ObstacleNebulaParticles?>();
        if (obstacles == null) return;
        foreach (ObstacleNebulaParticles? obstacle in obstacles)
        {
            for (int i = 0; i < obstacle?.ObstaclesAmount(); i++)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public override IReadOnlyCollection<ObstacleNebulaParticles?> GetObstacles()
    {
        return _obstacles;
    }
}