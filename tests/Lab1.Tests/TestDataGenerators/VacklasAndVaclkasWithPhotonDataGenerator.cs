using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class VacklasAndVaclkasWithPhotonDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _ships;

    public VacklasAndVaclkasWithPhotonDataGenerator()
    {
        var vacklasWithPhoton = new ShipVacklas();
        vacklasWithPhoton.Deflector = new PhotonDeflector(vacklasWithPhoton.Deflector);
        _ships = new List<object[]> { new object[] { new ShipVacklas(), vacklasWithPhoton } };
    }

    public IEnumerator<object[]> GetEnumerator() => _ships.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}