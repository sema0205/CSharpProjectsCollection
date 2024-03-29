using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleMeteoroid : IObstacleCosmos
{
    private const int DamagePoints = 10;

    public ObstacleMeteoroid(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; set; }

    public DamageResult DoDamage(IShip ship)
    {
        return ship.ReceiveDamage(DamagePoints);
    }
}