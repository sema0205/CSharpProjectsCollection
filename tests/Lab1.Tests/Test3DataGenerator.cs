using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test3DataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _ships = new List<object[]> { new object[] { new ShipVacklas(), new ShipAvgur(false, true), new ShipMeridian() } };

    public IEnumerator<object[]> GetEnumerator() => _ships.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}