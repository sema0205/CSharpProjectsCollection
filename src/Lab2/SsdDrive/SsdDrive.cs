using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;

public class SsdDrive : ISsdDrive
{
    public SsdDrive(
        SsdConnection connectionType,
        int memoryAmount,
        double maxWorkingSpeed,
        double powerConsumption)
    {
        ConnectionType = connectionType;
        MemoryAmount = memoryAmount;
        MaxWorkingSpeed = maxWorkingSpeed;
        PowerConsumption = powerConsumption;
    }

    public SsdConnection ConnectionType { get; }
    public int MemoryAmount { get; }
    public double MaxWorkingSpeed { get; }
    public double PowerConsumption { get; }
}