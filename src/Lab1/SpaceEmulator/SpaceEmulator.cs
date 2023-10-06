using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceEmulator;

public static class SpaceEmulator
{
    public static ModelInfo MakeFlight(IReadOnlyCollection<ISpace> spaces, IShip ship)
    {
        var model = new ModelInfo();
        var transferResult = new ModelInfo();
        foreach (ISpace space in spaces)
        {
            transferResult = space.SimulateTransfer(ship);
            model.FuelSpend += transferResult.FuelSpend;
            model.TimeSpent += transferResult.TimeSpent;
            if (transferResult.Result is DamageResult.Success) continue;
            model.Result = transferResult.Result;
            return model;
        }

        model.Result = transferResult.Result;
        return model;
    }
}