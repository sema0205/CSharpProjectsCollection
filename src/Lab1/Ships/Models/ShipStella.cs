using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;
using Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipStella : IShip, IShipWithPulseEngine, IShipWithJumpEngine
{
    public IEnginePulse PulseEngine { get; } = new EnginePulseC();

    public IEngineJump JumpEngine { get; } = new EngineJumpOmega();

    public IDeflector? Deflector { get; set; } = new Deflector1();

    public IHull Hull { get; } = new HullClass1();

    public DamageResult ReceiveDamage(int damageAmount)
    {
        if (Deflector is null)
        {
            return Hull.GetDamage(damageAmount);
        }

        DamageResult resultDeflector = Deflector.GetDamage(damageAmount);
        if (resultDeflector is Failed.LeftDamage leftDamage)
        {
            return Hull.GetDamage(leftDamage.DamageAmount);
        }

        return resultDeflector;
    }

    public void AddPhotonDeflector()
    {
        if (Deflector is not null)
            Deflector = new PhotonDeflector(Deflector);
    }
}