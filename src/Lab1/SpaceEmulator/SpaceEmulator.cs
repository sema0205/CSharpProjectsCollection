using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceEmulator;

public static class SpaceEmulator
{
    public static ModelInfo MakeFlight(IReadOnlyCollection<Space> spaces, Ship ship)
    {
        if (spaces.Any(space => !SimulateTransfer(space, ship)))
        {
            return ship.ReportInfo;
        }

        return ship.ReportInfo;
    }

    private static bool SimulateTransfer(Space space, Ship ship)
    {
        ship.ReportInfo.SuccessfulRoad = true;

        IBurnFuel? engine = PickEngine(space, ship);
        if (engine is null)
        {
            ship.ReportInfo.NotEnoughPower = true;
            ship.ReportInfo.SuccessfulRoad = false;
            return false;
        }

        ship.ReportInfo.FuelSpent = engine.CalculateFuel(space.Distance).GetPrice();

        if (space.GetObstacles().All(ship.GetDamage)) return true;
        ship.ReportInfo.ShipDestroyed = true;
        ship.ReportInfo.SuccessfulRoad = false;

        return false;
    }

    private static IBurnFuel? PickEngine(Space space, Ship ship)
    {
        IBurnFuel? bestEngine = null;

        foreach (IBurnFuel engine in ship.Engines)
        {
            if (engine.ValidateSpace(space))
            {
                bestEngine = engine;
            }
        }

        return bestEngine;
    }
}