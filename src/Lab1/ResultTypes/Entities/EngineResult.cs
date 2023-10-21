using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record EngineResult
{
    private EngineResult() { }

    public record Success : EngineResult;

    public sealed record Info(IFuel Fuel, int Time) : Success;

    public record Failed : EngineResult;
}