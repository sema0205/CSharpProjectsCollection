using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class PhotonDeflector : DeflectorDecorator
{
    private const double PhotonCoefficient = 1.3;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector) { }

    public double Health { get; private set; } = 100;

    public override DamageResult GetDamage(double damageAmount)
    {
        switch (damageAmount)
        {
            case >= 21 and <= 25:
                Health -= PhotonCoefficient * damageAmount;
                break;
            default:
                return Deflector.GetDamage(damageAmount);
        }

        return Health switch
        {
            <= 0 => new Success.DeflectorDisabled(),
            _ => new Success.AbsorbedHit(),
        };
    }
}