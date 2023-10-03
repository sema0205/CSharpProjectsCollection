using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public interface IDeflector
{
    public DamageResult GetDamage(double damageAmount);
}