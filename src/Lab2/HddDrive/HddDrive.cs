namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public class HddDrive : IHddDrive
{
    public HddDrive(int memoryAmount, double shaftSpeed, double powerConsumption)
    {
        MemoryAmount = memoryAmount;
        ShaftSpeed = shaftSpeed;
        PowerConsumption = powerConsumption;
    }

    public int MemoryAmount { get; }
    public double ShaftSpeed { get; }
    public double PowerConsumption { get; }
}