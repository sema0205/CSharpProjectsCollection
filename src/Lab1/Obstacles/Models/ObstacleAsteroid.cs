using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleAsteroid : ObstacleCosmos
{
    public ObstacleAsteroid(int amount = 1)
        : base(amount) { }

    public override bool DoDamage(IProtection? protection)
    {
        return protection?.DoAsteroidDamage() ?? false;
    }
}