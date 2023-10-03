using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleWhale : IObstacleNebulaParticles
{
    private const int DamagePoints = 20;

    public ObstacleWhale(int amount)
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
        if (ship is IShipWithAntiNitrideEmitter)
        {
            return new Success.AbsorbedHit();
        }

        if (ship.Deflector is null) return new Failed.ShipDestroyed();
        DamageResult resultHit = ship.Deflector.GetDamage(DamagePoints);
        return resultHit is Success ? resultHit : new Failed.ShipDestroyed();
    }
}