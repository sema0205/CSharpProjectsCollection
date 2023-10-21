using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipModifiers;

public interface IShipWithPulseEngine
{
    public IEnginePulse PulseEngine { get; }
}