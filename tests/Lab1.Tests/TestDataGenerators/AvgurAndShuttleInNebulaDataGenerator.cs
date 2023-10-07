using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AvgurAndShuttleInNebulaDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _ships = new List<object[]> { new object[] { new ShipShuttle(), new ShipAvgur() } };

    public IEnumerator<object[]> GetEnumerator() => _ships.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
