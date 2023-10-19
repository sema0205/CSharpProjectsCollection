using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface ICoolingSystem : IValidator<IProcessor>
{
    public CoolerDimension Size { get; }

    public IReadOnlyList<string> ProcessorSocket { get; }

    public double MaxTdpAmount { get; }
}