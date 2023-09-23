using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IBurnFuel
{
    public IResource CalculateFuel(int distance);

    public bool ValidateSpace(Space space);
}