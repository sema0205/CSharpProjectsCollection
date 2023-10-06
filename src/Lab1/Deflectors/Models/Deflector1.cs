using System;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector1 : IDeflector
{
    private const double SmallDamage = 12.5;

    private const double MiddleDamage = 12.5;

    private const double HighDamage = 6;

    public double Health { get; private set; } = 100;

    public DamageResult GetDamage(double damageAmount)
    {
        if (Health <= 0)
        {
            return new DamageResult.LeftDamage(damageAmount);
        }

        double leftDamage = 0;

        switch (damageAmount)
        {
            case >= 1 and <= 5:
                Health -= SmallDamage * damageAmount;
                leftDamage = Math.Abs(Health) / SmallDamage;
                break;
            case >= 6 and <= 10:
                Health -= MiddleDamage * damageAmount;
                leftDamage = Math.Abs(Health) / MiddleDamage;
                break;
            case >= 11 and <= 20:
                Health -= HighDamage * damageAmount;
                leftDamage = Math.Abs(Health) / HighDamage;
                break;
            default:
                Health = 0;
                break;
        }

        return Health switch
        {
            0 => new DamageResult.DeflectorDisabled(),
            < 0 => new DamageResult.LeftDamage(Math.Abs(leftDamage)),
            _ => new DamageResult.AbsorbedHit(),
        };
    }
}