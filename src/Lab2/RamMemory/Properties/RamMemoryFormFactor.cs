namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public abstract record RamMemoryFormFactor
{
    private RamMemoryFormFactor() { }

    public sealed record LrdImm : RamMemoryFormFactor;

    public sealed record RdImm : RamMemoryFormFactor;

    public sealed record DImm : RamMemoryFormFactor;
}