namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

public class Deflector1 : Deflector
{
    public Deflector1(bool photonSupport, int healthAmount = 3)
        : base(photonSupport, healthAmount) { }

    public override bool DoAsteroidDamage()
    {
        HealthAmount--;
        return HealthAmount > 0;
    }

    public override bool DoMeteoroidDamage()
    {
        HealthAmount -= 2;
        return HealthAmount > 0;
    }
}