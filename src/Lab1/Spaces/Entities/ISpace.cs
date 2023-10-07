using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public interface ISpace
{
    public int Distance { get; }

    public IReadOnlyCollection<IObstacle> GetObstacles();

    public ModelInfo SimulateTransfer(IShip ship);

    public EngineResult ValidateEngine(IShip ship);
}