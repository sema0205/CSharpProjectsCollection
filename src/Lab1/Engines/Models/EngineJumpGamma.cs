using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineJumpGamma : IEngineJump
{
    private const int JumpDistance = 500;

    private const int FuelUsageInfo = 6;

    public IFuel CalculateFuel(int distance)
    {
        double fuelUsageIntegral = Math.Pow(FuelUsageInfo, 3) / 3;
        double fuelAmount = (distance * fuelUsageIntegral) / 100;
        return new FuelPlasma(fuelAmount);
    }

    public int CalculateTime(int distance)
    {
        return (int)Math.Log(distance);
    }

    public DamageResult ValidateSpace(ISpace space)
    {
        if (space is not SpaceNebulaDensity)
        {
            return new Failed.ShipPowerLost();
        }

        if (space.Distance <= JumpDistance)
        {
            return new Success.SuccessfulRoad();
        }

        return new Failed.ShipPowerLost();
    }
}