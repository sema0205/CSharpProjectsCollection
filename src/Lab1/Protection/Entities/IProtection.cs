namespace Itmo.ObjectOrientedProgramming.Lab1.Protection;

public interface IProtection
{
    public int GetHealthInfo();

    public bool DoAsteroidDamage();

    public bool DoMeteoroidDamage();

    public bool DoPhotonDamage();

    public bool DoAntiNeutrinoDamage();
}