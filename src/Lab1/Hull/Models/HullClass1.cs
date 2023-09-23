namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public class HullClass1 : Hull
{
    public HullClass1(int weightClass, int healthAmount = 1)
        : base(weightClass, healthAmount) { }

    public override bool DoAsteroidDamage()
    {
        HealthAmount--;
        return HealthAmount > 0;
    }

    public override bool DoMeteoroidDamage()
    {
        return false;
    }
}