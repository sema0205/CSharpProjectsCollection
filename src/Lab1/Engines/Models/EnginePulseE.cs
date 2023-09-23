using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EnginePulseE : EnginePulse
{
    public EnginePulseE(int fuelUsage = 10, int speedInfo = 50)
        : base(fuelUsage, speedInfo) { }

    public override IResource CalculateFuel(int distance)
    {
        int time = distance / SpeedInfo;
        int fuelAmount = (int)Math.Exp(time);
        Fuel.CalculatePrice(fuelAmount);
        return Fuel;
    }

    public override bool ValidateSpace(Space space)
    {
        return space is SpaceCosmos or SpaceNebulaParticles;
    }
}