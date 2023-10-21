using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class Processor : IProcessor
{
    public Processor(
        double coreFrequency,
        int сoresAmount,
        string processorSocket,
        bool builtInVideoCardSupport,
        IEnumerable<double> memoryFrequency,
        double tdpAmount,
        double powerConsumption)
    {
        CoreFrequency = coreFrequency;
        СoresAmount = сoresAmount;
        ProcessorSocket = processorSocket;
        BuiltInVideoCardSupport = builtInVideoCardSupport;
        MemoryFrequency = memoryFrequency.ToList();
        TdpAmount = tdpAmount;
        PowerConsumption = powerConsumption;
    }

    public double CoreFrequency { get; }
    public int СoresAmount { get; }
    public string ProcessorSocket { get; }
    public bool BuiltInVideoCardSupport { get; }
    public IReadOnlyList<double> MemoryFrequency { get; }
    public double TdpAmount { get; }
    public double PowerConsumption { get; }
}