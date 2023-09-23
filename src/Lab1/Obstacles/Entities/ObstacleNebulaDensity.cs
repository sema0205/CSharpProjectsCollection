using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class ObstacleNebulaDensity : IObstacle
{
    protected ObstacleNebulaDensity(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; }
    public abstract bool DoDamage(IProtection? protection);

    public int ObstaclesAmount()
    {
        return Amount;
    }
}