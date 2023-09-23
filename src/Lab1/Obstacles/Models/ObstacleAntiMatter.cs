using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class ObstacleAntiMatter : ObstacleNebulaDensity
{
    public ObstacleAntiMatter(int amount = 1)
        : base(amount) { }

    public override bool DoDamage(IProtection? protection)
    {
        if (protection is Deflector deflector)
        {
            return deflector.DoPhotonDamage();
        }

        return false;
    }
}