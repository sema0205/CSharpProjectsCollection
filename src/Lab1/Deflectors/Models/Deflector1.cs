using System;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector1 : IDeflector
{
    private const double AsteroidCoefficient = 12.5;

    private const double MeteoroidCoefficient = 12.5;

    private const double WhaleCoefficient = 6;

    public double Health { get; private set; } = 100;

    public DamageResult GetDamage(double damageAmount)
    {
        if (Health <= 0)
        {
            return new Failed.LeftDamage(damageAmount);
        }

        double leftDamage = 0;

        switch (damageAmount)
        {
            case >= 1 and <= 5:
                Health -= AsteroidCoefficient * damageAmount;
                leftDamage = Math.Abs(Health) / AsteroidCoefficient;
                break;
            case >= 6 and <= 10:
                Health -= MeteoroidCoefficient * damageAmount;
                leftDamage = Math.Abs(Health) / MeteoroidCoefficient;
                break;
            case >= 11 and <= 20:
                Health -= WhaleCoefficient * damageAmount;
                leftDamage = Math.Abs(Health) / WhaleCoefficient;
                break;
            default:
                Health = 0;
                break;
        }

        return Health switch
        {
            0 => new Success.DeflectorDisabled(),
            < 0 => new Failed.LeftDamage(Math.Abs(leftDamage)),
            _ => new Success.AbsorbedHit(),
        };
    }
}