using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test2DataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _ships;

    public Test2DataGenerator()
    {
        var vacklasWithPhoton = new ShipVacklas();
        vacklasWithPhoton.AddPhotonDeflector();
        _ships = new List<object[]> { new object[] { new ShipVacklas(), vacklasWithPhoton } };
    }

    public IEnumerator<object[]> GetEnumerator() => _ships.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}