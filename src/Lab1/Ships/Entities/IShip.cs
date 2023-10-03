using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public interface IShip
{
    public IDeflector? Deflector { get; protected set; }

    public DoDamageResult ReceiveDamage(int damageAmount)
    {
        if (Deflector.GetDamage(damageAmount) is DoDamageResult.LeftDamage)
        {

        }
    }
}