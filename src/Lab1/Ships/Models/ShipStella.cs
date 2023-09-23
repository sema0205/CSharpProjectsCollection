using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipStella : Ship
{
    public ShipStella(bool photonSupport = false, bool matterSupport = false, int weightClass = 1)
        : base(new List<IBurnFuel> { new EnginePulseC(), new EngineJumpOmega() }, new Deflector1(photonSupport), new HullClass1(weightClass), matterSupport) { }
}