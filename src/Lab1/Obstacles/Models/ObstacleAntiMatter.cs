using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleAntiMatter : IObstacleNebulaDensity
{
    private const int DamagePoints = 25;

    public ObstacleAntiMatter(int amount)
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
        if (ship.Deflector is PhotonDeflector)
        {
            return ship.ReceiveDamage(DamagePoints);
        }

        return new Failed.ShipCrewDead();
    }
}