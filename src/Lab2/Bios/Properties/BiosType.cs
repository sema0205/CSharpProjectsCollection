namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public abstract record BiosType
{
    private BiosType() { }

    public sealed record Ami(int Version) : BiosType;

    public sealed record Phoenix(int Version) : BiosType;

    public sealed record Intel(int Version) : BiosType;

    public sealed record Uefi(int Version) : BiosType;
}