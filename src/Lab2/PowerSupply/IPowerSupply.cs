using Itmo.ObjectOrientedProgramming.Lab2.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupply : IValidator<double>
{
    public double PeakConsumptionLoad { get; }
}