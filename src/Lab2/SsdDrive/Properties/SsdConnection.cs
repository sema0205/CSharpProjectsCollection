namespace Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;

public abstract record SsdConnection
{
    private SsdConnection() { }

    public sealed record PciExpress : SsdConnection;

    public sealed record Sata : SsdConnection;
}