using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceNebulaParticles : ISpace
{
    private readonly List<IObstacleNebulaParticles> _obstacles;

    public SpaceNebulaParticles(IReadOnlyCollection<IObstacleNebulaParticles>? obstacles = null, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<IObstacleNebulaParticles>();
        if (obstacles == null) return;
        foreach (IObstacleNebulaParticles obstacle in obstacles)
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