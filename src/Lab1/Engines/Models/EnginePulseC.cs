using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EnginePulseC : IEnginePulse
{
    private const int SpeedInfo = 50;

    private const int FuelUsageInfo = 6;

    private const double SpaceCoefficient = 0.25;

    public EngineResult ValidateSpace(double coefficient, int distance)
    {
        if (coefficient > SpaceCoefficient)
        {
            return new EngineResult.Failed();
        }

        IFuel fuel = new FuelPlasma((distance * FuelUsageInfo) / 1000);
        int time = distance / SpeedInfo;

        return new EngineResult.Info(fuel, time);
    }
}