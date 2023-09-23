using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public interface IObstacle
{
    public bool DoDamage(IProtection? protection);

    public int ObstaclesAmount();
}