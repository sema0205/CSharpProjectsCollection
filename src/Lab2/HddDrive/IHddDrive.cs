namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public interface IHddDrive
{
    public int MemoryAmount { get; }

    public double ShaftSpeed { get; }

    public double PowerConsumption { get; }
}