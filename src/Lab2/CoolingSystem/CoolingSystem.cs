using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class CoolingSystem : ICoolingSystem
{
    public CoolingSystem(CoolerDimension size, IEnumerable<string> processorSocket, double maxTdpAmount)
    {
        Size = size;
        ProcessorSocket = processorSocket.ToList();
        MaxTdpAmount = maxTdpAmount;
    }

    public CoolerDimension Size { get; }
    public IReadOnlyList<string> ProcessorSocket { get; }
    public double MaxTdpAmount { get; }

    public CompatibilityConflict Validate(IProcessor computerDetail)
    {
        if (ProcessorSocket.All(processorSocket => processorSocket != computerDetail.ProcessorSocket))
            return new CompatibilityConflict.CoolingSystemAndProcessorDifferentSockets();

        if (MaxTdpAmount > computerDetail.PowerConsumption)
            return new CompatibilityConflict.CompatibilitySuccess();

        return new CompatibilityConflict.WarrantyDisclaimer();
    }
}