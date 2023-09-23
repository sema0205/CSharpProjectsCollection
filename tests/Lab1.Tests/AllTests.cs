using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AllTests
{
    [Theory]
    [ClassData(typeof(Test1DataGenerator))]
    public void Test1(Ship shuttle, Ship avgur)
    {
        var space = new SpaceNebulaDensity(null, MetricValues.MetricValues.MidDistance);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, shuttle);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, avgur);

        Assert.True(reportShuttle.NotEnoughPower);
        Assert.True(reportAvgur.NotEnoughPower);
    }

    [Theory]
    [ClassData(typeof(Test2DataGenerator))]
    public void Test2(Ship vacklas, Ship vacklasPhoton)
    {
        var spaceNebulaDensity = new SpaceNebulaDensity(new ObstacleNebulaDensity[] { new ObstacleAntiMatter() });
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { spaceNebulaDensity }, vacklas);
        ModelInfo reportVacklasPhoton = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { spaceNebulaDensity }, vacklasPhoton);

        Assert.True(reportVacklas.PeopleDead);
        Assert.True(reportVacklasPhoton.SuccessfulRoad);
    }

    [Theory]
    [ClassData(typeof(Test3DataGenerator))]
    public void Test3(Ship vacklas, Ship avgur, Ship meredian)
    {
        var space = new SpaceNebulaParticles(new ObstacleNebulaParticles[] { new ObstacleAntiNeutrino(2) });
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, vacklas);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, avgur);
        ModelInfo reportMeredian = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, meredian);

        Assert.True(reportVacklas.ShipDestroyed);
        Assert.True(reportAvgur.SuccessfulRoad);
        Assert.True(reportMeredian.SuccessfulRoad);
    }

    [Fact]
    public void Test4()
    {
        var shuttle = new ShipShuttle();
        var vacklas = new ShipVacklas();
        var space = new SpaceCosmos(null, MetricValues.MetricValues.ShortDistance);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, shuttle);
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, vacklas);
        Assert.True(reportShuttle.FuelSpent < reportVacklas.FuelSpent);
    }

    [Fact]
    public void Test5()
    {
        var avgur = new ShipAvgur();
        var stella = new ShipStella();
        var space = new SpaceNebulaDensity(null, MetricValues.MetricValues.MidDistance);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, avgur);
        ModelInfo reportStella = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, stella);
        Assert.True(reportAvgur.NotEnoughPower);
        Assert.True(reportStella.SuccessfulRoad);
    }

    [Fact]
    public void Test6()
    {
        var shuttle = new ShipShuttle();
        var vacklas = new ShipVacklas();
        var space = new SpaceNebulaParticles(null, MetricValues.MetricValues.MidDistance);
        ModelInfo reportShuttle = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, shuttle);
        ModelInfo reportVacklas = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { space }, vacklas);
        Assert.True(reportShuttle.NotEnoughPower);
        Assert.True(reportVacklas.SuccessfulRoad);
    }

    [Fact]
    public void Test7()
    {
        var avgur = new ShipAvgur();
        var spaceCosmos = new SpaceCosmos(new ObstacleCosmos[] { new ObstacleAsteroid(10), new ObstacleMeteoroid(4) }, MetricValues.MetricValues.ShortDistance);
        var spaceNebulaParticles = new SpaceNebulaParticles(null, MetricValues.MetricValues.ShortDistance);
        var spaceNebulaDensity = new SpaceNebulaDensity(new ObstacleNebulaDensity[] { new ObstacleAntiMatter() }, MetricValues.MetricValues.ShortDistance);
        ModelInfo reportAvgur = SpaceEmulator.SpaceEmulator.MakeFlight(new Space[] { spaceCosmos, spaceNebulaParticles, spaceNebulaDensity }, avgur);
        Assert.True(reportAvgur.PeopleDead);
    }
}