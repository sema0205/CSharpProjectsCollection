using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;
using Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipAvgur : IShip, IShipWithPulseEngine, IShipWithJumpEngine
{
    public IEnginePulse PulseEngine { get;  } = new EnginePulseE();

    public IEngineJump JumpEngine { get; } = new EngineJumpAlpha();

    public IDeflector Deflector { get; set; } = new Deflector3();

    public IHull Hull { get; } = new HullClass3();

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