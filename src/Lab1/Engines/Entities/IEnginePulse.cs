using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEnginePulse
{
    public EngineResult ValidateSpace(double coefficient, int distance);
}