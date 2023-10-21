using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public class Bios : IBios
{
    public Bios(BiosType biosType, IEnumerable<string> supportedProcessors)
    {
        BiosType = biosType;
        SupportedProcessors = supportedProcessors.ToArray();
    }

    public BiosType BiosType { get; }
    public IReadOnlyList<string> SupportedProcessors { get; }

    public CompatibilityConflict Validate(IProcessor computerDetail)
    {
        foreach (string supportedProcessor in SupportedProcessors)
        {
            if (supportedProcessor == computerDetail.ProcessorSocket)
                return new CompatibilityConflict.CompatibilitySuccess();
        }

        return new CompatibilityConflict.NoBiosSupportForProcessor();
    }
}