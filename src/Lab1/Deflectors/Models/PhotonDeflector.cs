using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class PhotonDeflector : DeflectorDecorator
{
    private const double PhotonDamage = 34;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector) { }

    public double Health { get; private set; } = 100;

    public override DamageResult GetDamage(double damageAmount)
    {
        return Deflector.GetDamage(damageAmount);
    }

    public DamageResult PhotonFlash()
    {
        Health -= PhotonDamage;

        return Health switch
        {
            <= 0 => new DamageResult.DeflectorDisabled(),
            _ => new DamageResult.AbsorbedHit(),
        };
    }
}