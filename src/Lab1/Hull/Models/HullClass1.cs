using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public class HullClass1 : IHull
{
    private const double AsteroidCoefficient = 20;

    private const double MeteoroidCoefficient = 11;

    private const double WhaleCoefficient = 6;

    public double Health { get; private set; } = 100;

    public DamageResult GetDamage(double damageAmount)
    {
        switch (damageAmount)
        {
            case >= 1 and <= 5:
                Health -= AsteroidCoefficient * damageAmount;
                break;
            case >= 6 and <= 10:
                Health -= MeteoroidCoefficient * damageAmount;
                break;
            case >= 11 and <= 20:
                Health -= WhaleCoefficient * damageAmount;
                break;
            default:
                Health = 0;
                break;
        }

        if (Health <= 0)
        {
            return new Failed.ShipDestroyed();
        }

        return new Success.AbsorbedHit();
    }
}