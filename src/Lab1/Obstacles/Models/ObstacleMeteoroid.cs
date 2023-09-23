using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleMeteoroid : ObstacleCosmos
{
    public ObstacleMeteoroid(int amount = 1)
        : base(amount) { }

    public override bool DoDamage(IProtection? protection)
    {
        return protection?.DoMeteoroidDamage() ?? false;
    }
}