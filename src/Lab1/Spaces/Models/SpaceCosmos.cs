using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Exchanges;
using Itmo.ObjectOrientedProgramming.Lab1.Exchanges.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class SpaceCosmos : ISpace
{
    private const double Coefficient = 0.2;

    private readonly List<IObstacleCosmos> _obstacles;

    public SpaceCosmos(IReadOnlyCollection<IObstacleCosmos>? obstacles = null, int distance = 250)
    {
        Distance = distance;
        _obstacles = new List<IObstacleCosmos>();
        if (obstacles == null) return;
        foreach (IObstacleCosmos obstacle in obstacles)
        {
            for (int i = 0; i < obstacle.Amount; i++)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public int Distance { get; }

    public IReadOnlyCollection<IObstacle> GetObstacles()
    {
        return _obstacles;
    }

    public ModelInfo SimulateTransfer(IShip ship)
    {
        var model = new ModelInfo();
        IExchange exchange = new FuelExchange();
        EngineResult engineResult = ValidateEngine(ship);

        switch (engineResult)
        {
            case EngineResult.Failed:
                model.Result = new DamageResult.ShipPowerLost();
                return model;
            case EngineResult.Info engineInfo:
                model.TimeSpent = engineInfo.Time;
                model.FuelSpend = exchange.CheckStockPrice(engineInfo.Fuel);
                break;
        }

        DamageResult obstacleHitResult = new DamageResult.SuccessfulRoad();
        foreach (IObstacle obstacle in _obstacles)
        {
            obstacleHitResult = obstacle.DoDamage(ship);
            if (obstacleHitResult is DamageResult.Success) continue;
            model.Result = obstacleHitResult;
            return model;
        }

        if (obstacleHitResult is DamageResult.AbsorbedHit)
        {
            model.Result = new DamageResult.SuccessfulRoad();
            return model;
        }

        model.Result = obstacleHitResult;
        return model;
    }

    public EngineResult ValidateEngine(IShip ship)
    {
        return ship switch
        {
            IShipWithPulseEngine pulseEngine => pulseEngine.PulseEngine.ValidateSpace(Coefficient, Distance),
            IShipWithJumpEngine jumpEngine => jumpEngine.JumpEngine.ValidateSpace(Distance),
            _ => new EngineResult.Failed(),
        };
    }
}