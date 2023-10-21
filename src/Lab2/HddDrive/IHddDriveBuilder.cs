namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public interface IHddDriveBuilder
{
    IHddDriveBuilder WithMemoryAmount(int memoryAmount);

    IHddDriveBuilder WithShaftSpeed(double shaftSpeed);

    IHddDriveBuilder WithPowerConsumption(double powerConsumption);

    IHddDrive Build();
}