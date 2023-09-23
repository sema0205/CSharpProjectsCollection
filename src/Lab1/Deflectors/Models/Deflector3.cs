namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

public class Deflector3 : Deflector
{
    public Deflector3(bool photonSupport, int healthAmount = 400)
        : base(photonSupport, healthAmount) { }

    public override bool DoAsteroidDamage()
    {
        HealthAmount -= 10;
        return HealthAmount > 0;
    }

    public override bool DoMeteoroidDamage()
    {
        HealthAmount -= 40;
        return HealthAmount > 0;
    }
}