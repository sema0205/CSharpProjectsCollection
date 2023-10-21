using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public interface IShip
{
    public IDeflector? Deflector { get; }
    public DamageResult ReceiveDamage(int damageAmount);
}