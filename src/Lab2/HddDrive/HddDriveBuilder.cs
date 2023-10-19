namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public class HddDriveBuilder : IHddDriveBuilder
{
    private int _memoryAmount;
    private double _shaftSpeed;
    private double _powerConsumption;

    public IHddDriveBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public IHddDriveBuilder WithShaftSpeed(double shaftSpeed)
    {
        _shaftSpeed = shaftSpeed;
        return this;
    }

    public IHddDriveBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHddDrive Build()
    {
        return new HddDrive(_memoryAmount, _shaftSpeed, _powerConsumption);
    }
}