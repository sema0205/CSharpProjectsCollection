using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineJumpAlpha : EngineJump
{
    public EngineJumpAlpha(int fuelUsage = 10, int speedInfo = 50, int jumpDistance = 250)
        : base(fuelUsage, speedInfo, jumpDistance) { }

    public override IResource CalculateFuel(int distance)
    {
        int fuelAmount = (distance * FuelUsageInfo) / 100;
        Fuel.CalculatePrice(fuelAmount);
        return Fuel;
    }

    public override bool ValidateSpace(Space space)
    {
        if (space is not SpaceNebulaDensity) return false;
        return space.Distance <= JumpDistance;
    }
}