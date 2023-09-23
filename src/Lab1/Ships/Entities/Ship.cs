using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class Ship
{
    private readonly IList<IBurnFuel> _engines;

    protected Ship(IEnumerable<IBurnFuel> engines, Deflector? deflector, Hull hull, bool matterSupport, int weight = 1)
    {
        _engines = engines.ToList();
        if (deflector is not null) deflector.AntiNeutrinoSupport = matterSupport;
        hull.AntiNeutrinoSupport = matterSupport;
        Deflector = deflector;
        Hull = hull;
        ShipWeight = weight;
        ReportInfo = new ModelInfo();
    }

    public IEnumerable<IBurnFuel> Engines => _engines;

    public int ShipWeight { get; }

    public ModelInfo ReportInfo { get; }

    private Hull Hull { get; }

    private Deflector? Deflector { get; }

    public bool GetDamage(IObstacle? obstacle)
    {
        if (obstacle is null) return false;

        if (CheckDeflectorHealth())
        {
            obstacle.DoDamage(Deflector);
        }
        else
        {
            obstacle.DoDamage(Hull);
        }

        if (CheckPeopleStatus())
        {
            return false;
        }

        if (CheckShipHealth()) return true;
        ReportInfo.ShipDestroyed = true;
        ReportInfo.SuccessfulRoad = false;
        return false;
    }

    private bool CheckShipHealth()
    {
        return CheckDeflectorHealth() || CheckHullHealth();
    }

    private bool CheckDeflectorHealth()
    {
        if (Deflector != null)
        {
            return Deflector.GetHealthInfo() > 0;
        }

        return false;
    }

    private bool CheckHullHealth()
    {
        return Hull.GetHealthInfo() > 0;
    }

    private bool CheckPeopleStatus()
    {
        bool setValue;

        if (Deflector != null)
        {
            setValue = Deflector.PeopleDead;
            if (setValue)
            {
                ReportInfo.PeopleDead = true;
                return true;
            }
        }

        setValue = Hull.PeopleDead;
        if (!setValue) return false;

        ReportInfo.PeopleDead = true;
        return true;
    }
}