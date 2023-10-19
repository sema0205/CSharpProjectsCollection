using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;

public interface ISsdDriveBuilder
{
    ISsdDriveBuilder WithConnectionType(SsdConnection ssdConnection);

    ISsdDriveBuilder WithMemoryAmount(int memoryAmount);

    ISsdDriveBuilder WithMaxWorkingSpeed(double maxWorkingSpeed);

    ISsdDriveBuilder WithPowerConsumption(double powerConsumption);

    ISsdDrive Build();
}