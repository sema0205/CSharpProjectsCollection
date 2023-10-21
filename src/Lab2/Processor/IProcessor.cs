using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessor
{
    public double CoreFrequency { get; }

    public int СoresAmount { get; }

    public string ProcessorSocket { get; }

    public bool BuiltInVideoCardSupport { get; }

    public IReadOnlyList<double> MemoryFrequency { get; }

    public double TdpAmount { get; }

    public double PowerConsumption { get; }
}