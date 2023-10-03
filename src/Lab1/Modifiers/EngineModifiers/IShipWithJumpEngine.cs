using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;

public interface IShipWithJumpEngine
{
    public IEngineJump JumpEngine { get; }
}