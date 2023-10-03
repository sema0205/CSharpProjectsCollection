using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EnginePulseE : IEnginePulse
{
    private const int FuelUsageInfo = 10;
    public IFuel CalculateFuel(int distance)
    {
        int fuelAmount = (distance * FuelUsageInfo) / 100;
        return new FuelPlasma(fuelAmount);
    }

    public int CalculateTime(int distance)
    {
        return (int)Math.Log(distance);
    }

    public DamageResult ValidateSpace(ISpace space)
    {
        if (space is SpaceCosmos or SpaceNebulaParticles)
        {
            return new Success.SuccessfulRoad();
        }

        return new Failed.ShipPowerLost();
    }
}