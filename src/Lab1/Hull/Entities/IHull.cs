using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public interface IHull : IProtection
{
    // protected Hull(int weightClass, int healthAmount)
    // {
    //     HealthAmount = healthAmount * weightClass;
    // }
    //
    // public bool PeopleDead { get; private set; }
    //
    // public bool AntiNeutrinoSupport { get; set; }
    //
    // protected int HealthAmount { get; set; }
    //
    // public int GetHealthInfo()
    // {
    //     return HealthAmount;
    // }
    //
    // public abstract bool DoAsteroidDamage();
    //
    // public abstract bool DoMeteoroidDamage();
    //
    // public bool DoPhotonDamage()
    // {
    //     HealthAmount = 0;
    //     PeopleDead = true;
    //     return false;
    // }
    //
    // public bool DoAntiNeutrinoDamage()
    // {
    //     if (AntiNeutrinoSupport) return true;
    //     HealthAmount = 0;
    //     return false;
    // }
}