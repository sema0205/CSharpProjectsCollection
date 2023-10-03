using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AllTests
{
    [Theory]
    [ClassData(typeof(Test1DataGenerator))]
    public void Test1(IShip shuttle, IShip avgur)
    {
        var space = new SpaceNebulaDensity(null, MetricValues.MetricValues.MidDistance);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, shuttle);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, avgur);

        Assert.Equal(new Failed.ShipPowerLost(), reportShuttle.Result);
        Assert.Equal(new Failed.ShipPowerLost(), reportAvgur.Result);
    }

    [Theory]
    [ClassData(typeof(Test2DataGenerator))]
    public void Test2(IShip vacklas, IShip vacklasPhoton)
    {
        var spaceNebulaDensity = new SpaceNebulaDensity(new IObstacleNebulaDensity[] { new ObstacleAntiMatter(1) });
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { spaceNebulaDensity }, vacklas);
        ModelInfo reportVacklasPhoton = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { spaceNebulaDensity }, vacklasPhoton);

        Assert.Equal(new Failed.ShipCrewDead(), reportVacklas.Result);
        Assert.Equal(new Success.SuccessfulRoad(), reportVacklasPhoton.Result);
    }

    [Theory]
    [ClassData(typeof(Test3DataGenerator))]
    public void Test3(IShip vacklas, IShip avgur, IShip meredian)
    {
        var space = new SpaceNebulaParticles(new IObstacleNebulaParticles[] { new ObstacleWhale(1) });
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, vacklas);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, avgur);
        ModelInfo reportMeredian = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, meredian);

        Assert.Equal(new Failed.ShipDestroyed(), reportVacklas.Result);
        Assert.Equal(new Success.DeflectorDisabled(), reportAvgur.Result);
        Assert.Equal(new Success.SuccessfulRoad(), reportMeredian.Result);
    }

    [Fact]
    public void Test4()
    {
        var shuttle = new ShipShuttle();
        var vacklas = new ShipVacklas();
        var space = new SpaceCosmos(null, MetricValues.MetricValues.ShortDistance);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, shuttle);
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, vacklas);
        Assert.True(reportShuttle.FuelSpend < reportVacklas.FuelSpend);
    }

    [Fact]
    public void Test5()
    {
        var avgur = new ShipAvgur();
        var stella = new ShipStella();
        var space = new SpaceNebulaDensity(null, MetricValues.MetricValues.MidDistance);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, avgur);
        ModelInfo reportStella = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, stella);
        Assert.Equal(new Failed.ShipPowerLost(), reportAvgur.Result);
        Assert.Equal(new Success.SuccessfulRoad(), reportStella.Result);
    }

    [Fact]
    public void Test6()
    {
        var shuttle = new ShipShuttle();
        var vacklas = new ShipVacklas();
        var space = new SpaceNebulaParticles(null, MetricValues.MetricValues.MidDistance);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, shuttle);
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { space }, vacklas);
        Assert.Equal(new Failed.ShipPowerLost(), reportShuttle.Result);
        Assert.Equal(new Success.SuccessfulRoad(), reportVacklas.Result);
    }

    [Fact]
    public void Test7()
    {
        var avgur = new ShipAvgur();
        var spaceCosmos = new SpaceCosmos(new IObstacleCosmos[] { new ObstacleAsteroid(10), new ObstacleMeteoroid(4) }, MetricValues.MetricValues.ShortDistance);
        var spaceNebulaParticles = new SpaceNebulaParticles(null, MetricValues.MetricValues.ShortDistance);
        var spaceNebulaDensity = new SpaceNebulaDensity(new IObstacleNebulaDensity[] { new ObstacleAntiMatter(1) }, MetricValues.MetricValues.ShortDistance);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new ISpace[] { spaceCosmos, spaceNebulaParticles, spaceNebulaDensity }, avgur);
        Assert.Equal(new Failed.ShipCrewDead(), reportAvgur.Result);
    }
}