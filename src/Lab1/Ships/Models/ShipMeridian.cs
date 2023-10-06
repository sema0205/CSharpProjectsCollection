using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;
using Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipMeridian : IShip, IShipWithPulseEngine, IShipWithAntiNitrideEmitter
{
    public IEnginePulse PulseEngine { get; } = new EnginePulseE();

    public IDeflector Deflector { get; set; } = new Deflector2();

    public IHull Hull { get; set; } = new HullClass2();

    public DamageResult ReceiveDamage(int damageAmount)
    {
        if (Deflector is null)
        {
            return Hull.GetDamage(damageAmount);
        }

        DamageResult resultDeflector = Deflector.GetDamage(damageAmount);
        if (resultDeflector is DamageResult.LeftDamage leftDamage)
        {
            return Hull.GetDamage(leftDamage.DamageAmount);
        }

        return resultDeflector;
    }
}