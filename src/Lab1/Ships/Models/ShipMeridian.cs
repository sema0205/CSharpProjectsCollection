using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipMeridian : Ship
{
    public ShipMeridian(bool photonSupport = false, bool matterSupport = true, int weightClass = 2)
        : base(new List<IBurnFuel> { new EnginePulseE() }, new Deflector2(photonSupport), new HullClass2(weightClass), matterSupport) { }
}