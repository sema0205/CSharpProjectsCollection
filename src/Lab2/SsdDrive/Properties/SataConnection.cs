namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public abstract record SataConnection
{
    private SataConnection() { }

    public sealed record SataV1() : SataConnection;

    public sealed record SataV2() : SataConnection;

    public sealed record SataV3() : SataConnection;
}