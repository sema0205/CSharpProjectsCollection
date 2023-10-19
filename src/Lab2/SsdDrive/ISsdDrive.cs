using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;

public interface ISsdDrive
{
    public SsdConnection ConnectionType { get; }

    public int MemoryAmount { get; }

    public double MaxWorkingSpeed { get; }

    public double PowerConsumption { get; }
}