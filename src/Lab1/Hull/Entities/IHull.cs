using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public interface IHull
{
    public DamageResult GetDamage(double damageAmount);
}