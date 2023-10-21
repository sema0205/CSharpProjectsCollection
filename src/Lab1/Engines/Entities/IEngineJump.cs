using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEngineJump
{
    public EngineResult ValidateSpace(int distance);
}