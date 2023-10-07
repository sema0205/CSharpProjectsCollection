using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineJumpAlpha : IEngineJump
{
    private const int JumpDistance = 250;

    private const int FuelUsageInfo = 6;

    public EngineResult ValidateSpace(int distance)
    {
        if (distance > JumpDistance)
        {
            return new EngineResult.Failed();
        }

        IFuel fuel = new FuelPlasma(distance * FuelUsageInfo / 100);
        int time = (int)Math.Log(distance);

        return new EngineResult.Info(fuel, time);
    }
}