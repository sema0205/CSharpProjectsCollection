using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Selectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestCases
{
    [Theory]
    [ClassData(typeof(AvgurAndShuttleInNebulaDataGenerator))]
    public void TestAvgurAndShuttleInNebulaDensitySpaceWithMiddleDistance(IShip shuttle, IShip avgur)
    {
        var space = new SpaceNebulaDensity(null, 500);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, shuttle);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, avgur);

        Assert.Equal(new DamageResult.ShipPowerLost(), reportShuttle.Result);
        Assert.Equal(new DamageResult.ShipPowerLost(), reportAvgur.Result);
    }

    [Theory]
    [ClassData(typeof(VacklasAndVaclkasWithPhotonDataGenerator))]
    public void TestVacklasAndVaclkasWithPhotonInNebulaDensitySpaceWithLowDistance(IShip vacklas, IShip vacklasPhoton)
    {
        var spaceNebulaDensity = new SpaceNebulaDensity(new IObstacleNebulaDensity[] { new ObstacleAntiMatter(1) });
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { spaceNebulaDensity }, vacklas);
        ModelInfo reportVacklasPhoton = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { spaceNebulaDensity }, vacklasPhoton);

        Assert.Equal(new DamageResult.ShipCrewDead(), reportVacklas.Result);
        Assert.Equal(new DamageResult.SuccessfulRoad(), reportVacklasPhoton.Result);

        var sortedReports = new List<ModelInfo> { reportVacklas, reportVacklasPhoton };
        sortedReports.Sort(new ResultSelector());
        Assert.Equal(reportVacklasPhoton, sortedReports[0]);
        Assert.Equal(reportVacklas, sortedReports[1]);
    }

    [Theory]
    [ClassData(typeof(VacklasAndAvgurAndMeredianDataGenerator))]
    public void TestVacklasAndAvgurAndMeredianInNebulaParticlesSpaceWithLowDistance(IShip vacklas, IShip avgur, IShip meredian)
    {
        var space = new SpaceNebulaParticles(new IObstacleNebulaParticles[] { new ObstacleWhale(1) });
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, vacklas);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, avgur);
        ModelInfo reportMeredian = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, meredian);

        Assert.Equal(new DamageResult.ShipDestroyed(), reportVacklas.Result);
        Assert.Equal(new DamageResult.DeflectorDisabled(), reportAvgur.Result);
        Assert.Equal(new DamageResult.SuccessfulRoad(), reportMeredian.Result);

        var sortedReports = new List<ModelInfo> { reportVacklas, reportAvgur, reportMeredian };
        sortedReports.Sort(new ResultSelector());
        Assert.Equal(reportAvgur, sortedReports[0]);
        Assert.Equal(reportMeredian, sortedReports[1]);
        Assert.Equal(reportVacklas, sortedReports[2]);
    }

    [Fact]
    public void TestVacklasAndAvgurAndMeredianInCosmosSpaceWithLowDistance()
    {
        var shuttle = new ShipShuttle();
        var vacklas = new ShipVacklas();
        var space = new SpaceCosmos();

        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, shuttle);
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, vacklas);
        Assert.True(reportShuttle.FuelSpend < reportVacklas.FuelSpend);

        var sortedReports = new List<ModelInfo> { reportShuttle, reportVacklas };
        sortedReports.Sort(new FuelSelector());
        Assert.Equal(reportShuttle, sortedReports[0]);
        Assert.Equal(reportVacklas, sortedReports[1]);
    }

    [Fact]
    public void TestAvgurAndStellaInNebulaDensitySpaceWithMiddleDistance()
    {
        var avgur = new ShipAvgur();
        var stella = new ShipStella();
        var space = new SpaceNebulaDensity(null, 500);

        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, avgur);
        ModelInfo reportStella = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, stella);

        Assert.Equal(new DamageResult.ShipPowerLost(), reportAvgur.Result);
        Assert.Equal(new DamageResult.SuccessfulRoad(), reportStella.Result);

        var sortedReports = new List<ModelInfo> { reportAvgur, reportStella };
        sortedReports.Sort(new ResultSelector());
        Assert.Equal(reportStella, sortedReports[0]);
        Assert.Equal(reportAvgur, sortedReports[1]);
    }

    [Fact]
    public void TestShuttleAndVacklasInNebulaParticlesSpaceWithMiddleDistance()
    {
        var shuttle = new ShipShuttle();
        var vacklas = new ShipVacklas();
        var space = new SpaceNebulaParticles(null, 500);

        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, shuttle);
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, vacklas);

        Assert.Equal(new DamageResult.ShipPowerLost(), reportShuttle.Result);
        Assert.Equal(new DamageResult.SuccessfulRoad(), reportVacklas.Result);

        var sortedReports = new List<ModelInfo> { reportVacklas, reportShuttle };
        sortedReports.Sort(new ResultSelector());
        Assert.Equal(reportVacklas, sortedReports[0]);
        Assert.Equal(reportShuttle, sortedReports[1]);
    }

    [Fact]
    public void TestAvgurCustomFlight()
    {
        var avgur = new ShipAvgur();

        var spaceCosmos = new SpaceCosmos(new IObstacleCosmos[] { new ObstacleAsteroid(10), new ObstacleMeteoroid(4) }, 250);
        var spaceNebulaParticles = new SpaceNebulaParticles(null, 250);
        var spaceNebulaDensity = new SpaceNebulaDensity(new IObstacleNebulaDensity[] { new ObstacleAntiMatter(1) }, 250);

        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { spaceCosmos, spaceNebulaParticles, spaceNebulaDensity }, avgur);
        Assert.Equal(new DamageResult.ShipCrewDead(), reportAvgur.Result);
    }
}