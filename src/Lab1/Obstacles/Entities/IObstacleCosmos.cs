using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public interface ObstacleCosmos : IObstacle
{
    protected ObstacleCosmos(int amount)
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