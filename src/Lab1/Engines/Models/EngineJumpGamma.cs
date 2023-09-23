using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineJumpGamma : EngineJump
{
    public EngineJumpGamma(int fuelUsage = 10, int speedInfo = 50, int jumpDistance = 500)
        : base(fuelUsage, speedInfo, jumpDistance) { }

    public override IResource CalculateFuel(int distance)
    {
        int time = distance / SpeedInfo;
        int fuelAmount = (int)Math.Pow(time, 3) / 3;
        Fuel.CalculatePrice(fuelAmount);
        return Fuel;
    }

    public override bool ValidateSpace(Space space)
    {
        if (space is not SpaceNebulaDensity) return false;
        return space.Distance <= JumpDistance;
    }
}