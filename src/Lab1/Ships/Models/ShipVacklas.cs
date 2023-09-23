using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipVacklas : Ship
{
    public ShipVacklas(bool photonSupport = false, bool matterSupport = false, int weightClass = 2)
        : base(new List<IBurnFuel> { new EnginePulseE(), new EngineJumpGamma() }, new Deflector1(photonSupport), new HullClass2(weightClass), matterSupport) { }
}