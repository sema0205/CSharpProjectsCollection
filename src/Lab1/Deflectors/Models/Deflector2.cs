namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

public class Deflector2 : Deflector
{
    public Deflector2(bool photonSupport, int healthAmount = 30)
        : base(photonSupport, healthAmount) { }

    public override bool DoAsteroidDamage()
    {
        HealthAmount -= 3;
        return HealthAmount > 0;
    }

    public override bool DoMeteoroidDamage()
    {
        HealthAmount -= 10;
        return HealthAmount > 0;
    }
}