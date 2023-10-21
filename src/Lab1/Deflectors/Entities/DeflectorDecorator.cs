using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class DeflectorDecorator : IDeflector
{
    protected DeflectorDecorator(IDeflector deflector)
    {
        Deflector = deflector;
    }

    public IDeflector Deflector { get; }

    public abstract DamageResult GetDamage(double damageAmount);
}