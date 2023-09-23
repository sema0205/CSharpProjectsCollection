using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineJumpOmega : EngineJump
{
    public EngineJumpOmega(int fuelUsage = 10, int speedInfo = 50, int jumpDistance = 1000)
        : base(fuelUsage, speedInfo, jumpDistance) { }

    public override IResource CalculateFuel(int distance)
    {
        int time = distance / SpeedInfo;
        int fuelAmount = time * (int)Math.Log(time);
        Fuel.CalculatePrice(fuelAmount);
        return Fuel;
    }

    public override bool ValidateSpace(Space space)
    {
        if (space is not SpaceNebulaDensity) return false;
        return space.Distance <= JumpDistance;
    }
}