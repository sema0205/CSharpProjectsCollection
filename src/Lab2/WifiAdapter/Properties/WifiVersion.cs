namespace Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter.Properties;

public abstract record WifiVersion
{
    private WifiVersion() { }

    public sealed record A802 : WifiVersion;

    public sealed record Ac802 : WifiVersion;

    public sealed record B802 : WifiVersion;

    public sealed record G802 : WifiVersion;

    public sealed record N802 : WifiVersion;

    public sealed record Bgn802 : WifiVersion;

    public sealed record Ax802 : WifiVersion;
}