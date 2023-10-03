using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public interface IDeflector : IProtection
{


    // protected Deflector(bool photonSupport, int healthAmount)
    // {
    //     if (photonSupport)
    //     {
    //         PhotonHealth = 3;
    //     }
    //
    //     HealthAmount = healthAmount;
    // }
    //
    // public bool PeopleDead { get; protected set; }
    //
    // public bool AntiNeutrinoSupport { get; set; }
    //
    // protected int HealthAmount { get; set; }
    //
    // private int PhotonHealth { get; set; }
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
    //     PhotonHealth -= 1;
    //     if (PhotonHealth >= 0) return PhotonHealth > 0;
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