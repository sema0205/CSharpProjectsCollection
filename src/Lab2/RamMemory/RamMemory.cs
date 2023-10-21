using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public class RamMemory : IRamMemory
{
    public RamMemory(
        int memoryAmount,
        IEnumerable<JedecConfiguration> jedecConfigurations,
        IEnumerable<XmpProfileInfo> xmpProfiles,
        RamMemoryFormFactor formFactor,
        DdrType ddrVersion,
        double powerConsumption)
    {
        MemoryAmount = memoryAmount;
        JedecConfigurations = jedecConfigurations.ToArray();
        XmpProfiles = xmpProfiles.ToArray();
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public int MemoryAmount { get; }
    public IReadOnlyList<JedecConfiguration> JedecConfigurations { get; }
    public IReadOnlyList<XmpProfileInfo> XmpProfiles { get; }
    public RamMemoryFormFactor FormFactor { get; }
    public DdrType DdrVersion { get; }
    public double PowerConsumption { get; }
}