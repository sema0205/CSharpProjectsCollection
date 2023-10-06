namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record DamageResult
{
    private DamageResult() { }

    public record Success : DamageResult;

    public sealed record SuccessfulRoad : Success;

    public sealed record AbsorbedHit : Success;

    public sealed record DeflectorDisabled : Success;

    public record Failed : DamageResult;

    public sealed record ShipDestroyed : Failed;

    public sealed record ShipPowerLost : Failed;

    public sealed record ShipCrewDead : Failed;

    public sealed record LeftDamage(double DamageAmount) : Failed;
}