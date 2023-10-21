namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public abstract record DdrType
{
    private DdrType() { }

    public sealed record Ddr3 : DdrType;

    public sealed record Ddr4 : DdrType;

    public sealed record Ddr5 : DdrType;
}