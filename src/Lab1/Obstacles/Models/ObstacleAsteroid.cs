using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleAsteroid : IObstacleCosmos
{
    private const int DamagePoints = 5;

    public ObstacleAsteroid(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; }

    public int ObstaclesAmount()
    {
        return Amount;
    }

    public DamageResult DoDamage(IShip ship)
    {
        return ship.ReceiveDamage(DamagePoints);
    }
}