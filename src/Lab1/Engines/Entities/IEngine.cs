using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEngine
{
    public IFuel CalculateFuel(int distance);

    public int CalculateTime(int distance);

    public DamageResult ValidateSpace(ISpace space);
}