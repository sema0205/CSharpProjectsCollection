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

    public int Amount { get; set; }

    public DamageResult DoDamage(IShip ship)
    {
        if (ship is IShipWithAntiNitrideEmitter)
        {
            return new DamageResult.AbsorbedHit();
        }

        if (ship.Deflector is null) return new DamageResult.ShipDestroyed();
        DamageResult resultHit = ship.Deflector.GetDamage(DamagePoints);
        return resultHit is DamageResult.Success ? resultHit : new DamageResult.ShipDestroyed();
    }
}