using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleAntiNeutrino : IObstacleNebulaParticles
{
    protected ObstacleAntiNeutrino(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; }

    public int ObstaclesAmount()
    {
        return Amount;
    }

    public bool DoDamage(IProtection? protection)
    {
        return protection?.DoAntiNeutrinoDamage() ?? false;
    }
}