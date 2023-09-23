using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ShipShuttle : Ship
{
    public ShipShuttle(bool matterSupport = false, int weightClass = 1)
        : base(new List<IBurnFuel> { new EnginePulseC() }, null, new HullClass1(weightClass), matterSupport) { }
}