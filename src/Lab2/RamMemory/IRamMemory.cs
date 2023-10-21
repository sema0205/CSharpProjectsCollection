using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public interface IRamMemory
{
    public int MemoryAmount { get; }

    public IReadOnlyList<JedecConfiguration> JedecConfigurations { get; }

    public IReadOnlyList<XmpProfileInfo> XmpProfiles { get; }

    public RamMemoryFormFactor FormFactor { get; }

    public DdrType DdrVersion { get; }

    public double PowerConsumption { get; }
}