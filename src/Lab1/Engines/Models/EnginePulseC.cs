using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EnginePulseC : EnginePulse
{
    public EnginePulseC(int fuelUsage = 10, int speedInfo = 50)
        : base(fuelUsage, speedInfo) { }

    public override IResource CalculateFuel(int distance)
    {
        int fuelAmount = (distance * FuelUsageInfo) / 100;
        Fuel.CalculatePrice(fuelAmount);
        return Fuel;
    }

    public override bool ValidateSpace(Space space)
    {
        return space is SpaceCosmos;
    }
}