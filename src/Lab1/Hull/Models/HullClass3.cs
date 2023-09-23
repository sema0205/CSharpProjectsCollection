namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public class HullClass3 : Hull
{
    public HullClass3(int weightClass, int healthAmount = 100)
        : base(weightClass, healthAmount) { }

    public override bool DoAsteroidDamage()
    {
        HealthAmount -= 5;
        return HealthAmount > 0;
    }

    public override bool DoMeteoroidDamage()
    {
        HealthAmount -= 20;
        return HealthAmount > 0;
    }
}