using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class EnginePulse : IBurnFuel
{
    protected EnginePulse(int fuelUsage, int speedInfo)
    {
        FuelUsageInfo = fuelUsage;
        SpeedInfo = speedInfo;
    }

    protected FuelPlasma Fuel { get; } = new FuelPlasma();

    protected int FuelUsageInfo { get; }

    protected int SpeedInfo { get; }

    public abstract IResource CalculateFuel(int distance);

    public abstract bool ValidateSpace(Space space);
}