using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Exchanges;
using Itmo.ObjectOrientedProgramming.Lab1.Exchanges.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceEmulator;

public static class SpaceEmulator
{
    public static ModelInfo MakeFlight(IReadOnlyCollection<ISpace> spaces, IShip ship)
    {
        var model = new ModelInfo();
        DamageResult transferResult = new Success.SuccessfulRoad();
        foreach (ISpace space in spaces)
        {
            transferResult = SimulateTransfer(space, ship, model);
            if (transferResult is Success) continue;
            model.Result = transferResult;
            return model;
        }

        model.Result = transferResult;
        return model;
    }

    private static DamageResult SimulateTransfer(ISpace space, IShip ship, ModelInfo model)
    {
        IExchange exchange = new FuelExchange();
        IEngine? engine = PickEngine(space, ship);
        if (engine is null)
        {
            return new Failed.ShipPowerLost();
        }

        IFuel fuel = engine.CalculateFuel(space.Distance);
        model.TimeSpent += engine.CalculateTime(space.Distance);
        model.FuelSpend += exchange.CheckStockPrice(fuel);

        DamageResult obstacleHitResult = new Success.SuccessfulRoad();
        foreach (IObstacle obstacle in space.GetObstacles())
        {
            obstacleHitResult = obstacle.DoDamage(ship);
            if (obstacleHitResult is not Success)
            {
                return obstacleHitResult;
            }
        }

        return obstacleHitResult is Success.AbsorbedHit ? new Success.SuccessfulRoad() : obstacleHitResult;
    }

    private static IEngine? PickEngine(ISpace space, IShip ship)
    {
        IEngine? bestEngine = null;

        if (ship is IShipWithPulseEngine pulseEngine)
        {
            if (pulseEngine.PulseEngine.ValidateSpace(space) is Success.SuccessfulRoad)
            {
                bestEngine = pulseEngine.PulseEngine;
            }
        }

        if (ship is IShipWithJumpEngine engine)
        {
            if (engine.JumpEngine.ValidateSpace(space) is Success.SuccessfulRoad)
            {
                bestEngine = engine.JumpEngine;
            }
        }

        return bestEngine;
    }
}