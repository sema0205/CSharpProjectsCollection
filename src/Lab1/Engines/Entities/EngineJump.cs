using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class EngineJump : IBurnFuel
{
    protected EngineJump(int fuelUsage, int speedInfo, int jumpDistance)
    {
        FuelUsageInfo = fuelUsage;
        SpeedInfo = speedInfo;
        JumpDistance = jumpDistance;
    }

    protected FuelGraviton Fuel { get; } = new FuelGraviton();

    protected int FuelUsageInfo { get; }

    protected int SpeedInfo { get; }

    protected int JumpDistance { get; }

    public abstract IResource CalculateFuel(int distance);

    public abstract bool ValidateSpace(Space space);
}