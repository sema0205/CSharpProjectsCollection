using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleAntiMatter : IObstacleNebulaDensity
{
    public ObstacleAntiMatter(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; set; }

    public DamageResult DoDamage(IShip ship)
    {
        if (ship.Deflector is PhotonDeflector photonDeflector)
        {
           return photonDeflector.PhotonFlash();
        }

        return new DamageResult.ShipCrewDead();
    }
}