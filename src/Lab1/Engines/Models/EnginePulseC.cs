using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EnginePulseC : IEnginePulse
{
    private const int SpeedInfo = 50;

    private const int FuelUsageInfo = 6;

    public IFuel CalculateFuel(int distance)
    {
        int fuelAmount = (distance * FuelUsageInfo) / 100;
        return new FuelPlasma(fuelAmount);
    }

    public int CalculateTime(int distance)
    {
        return distance / SpeedInfo;
    }

    public DamageResult ValidateSpace(ISpace space)
    {
        if (space is SpaceCosmos)
        {
            return new Success.SuccessfulRoad();
        }

        return new Failed.ShipPowerLost();
    }
}