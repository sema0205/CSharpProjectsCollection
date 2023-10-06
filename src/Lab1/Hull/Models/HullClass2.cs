using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public class HullClass2 : IHull
{
    private const double SmallDamage = 4;

    private const double MiddleDamage = 50;

    private const double HighDamage = 6;

    public double Health { get; private set; } = 100;

    public DamageResult GetDamage(double damageAmount)
    {
        switch (damageAmount)
        {
            case >= 1 and <= 5:
                Health -= SmallDamage * damageAmount;
                break;
            case >= 6 and <= 10:
                Health -= MiddleDamage * damageAmount;
                break;
            case >= 11 and <= 20:
                Health -= HighDamage * damageAmount;
                break;
            default:
                Health = 0;
                break;
        }

        if (Health <= 0)
        {
            return new DamageResult.ShipDestroyed();
        }

        return new DamageResult.AbsorbedHit();
    }
}