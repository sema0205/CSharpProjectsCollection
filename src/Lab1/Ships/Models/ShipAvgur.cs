using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipAvgur : Ship
{
    public ShipAvgur(bool photonSupport = false, bool matterSupport = false, int weightClass = 3)
        : base(new List<IBurnFuel> { new EnginePulseE(), new EngineJumpAlpha() }, new Deflector3(photonSupport), new HullClass3(weightClass), matterSupport) { }
}