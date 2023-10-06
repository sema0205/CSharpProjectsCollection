using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public interface IObstacle
{
    public int Amount { get; set; }

    public DamageResult DoDamage(IShip ship);
}