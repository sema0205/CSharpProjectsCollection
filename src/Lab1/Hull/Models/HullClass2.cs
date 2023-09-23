namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public class HullClass2 : Hull
{
    public HullClass2(int weightClass, int healthAmount = 10)
        : base(weightClass, healthAmount) { }

    public override bool DoAsteroidDamage()
    {
        HealthAmount -= 2;
        return HealthAmount > 0;
    }

    public override bool DoMeteoroidDamage()
    {
        HealthAmount -= 5;
        return HealthAmount > 0;
    }
}