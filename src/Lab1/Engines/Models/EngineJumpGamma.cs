using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineJumpGamma : IEngineJump
{
    private const int JumpDistance = 500;

    private const int FuelUsageInfo = 6;

    public EngineResult ValidateSpace(int distance)
    {
        if (distance > JumpDistance)
        {
            return new EngineResult.Failed();
        }

        double fuelUsageIntegral = Math.Pow(FuelUsageInfo, 3) / 3;
        IFuel fuel = new FuelPlasma((distance * fuelUsageIntegral) / 100);
        int time = (int)Math.Log(distance);

        return new EngineResult.Info(fuel, time);
    }
}