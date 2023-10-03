namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record Failed : DamageResult
{
    private Failed() { }

    public sealed record ShipDestroyed : Failed;

    public sealed record ShipPowerLost : Failed;

    public sealed record ShipCrewDead : Failed;

    public sealed record LeftDamage(double DamageAmount) : Failed;
}
