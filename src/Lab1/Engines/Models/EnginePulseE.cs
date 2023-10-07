using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EnginePulseE : IEnginePulse
{
    private const int FuelUsageInfo = 10;

    private const double SpaceCoefficient = 0.6;

    public EngineResult ValidateSpace(double coefficient, int distance)
    {
        if (coefficient > SpaceCoefficient)
        {
            return new EngineResult.Failed();
        }

        IFuel fuel = new FuelPlasma((distance * FuelUsageInfo) / 100);
        int time = (int)Math.Log(distance);

        return new EngineResult.Info(fuel, time);
    }
}