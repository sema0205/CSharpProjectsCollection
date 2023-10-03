namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record Success : DamageResult
{
    private Success() { }

    public sealed record SuccessfulRoad : Success;

    public sealed record AbsorbedHit : Success;

    public sealed record DeflectorDisabled : Success;
}