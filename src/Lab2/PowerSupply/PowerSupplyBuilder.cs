namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private double _peakConsumptionLoad;

    public IPowerSupplyBuilder WithPeakConsumptionLoad(double peakConsumptionLoad)
    {
        _peakConsumptionLoad = peakConsumptionLoad;
        return this;
    }

    public IPowerSupply Build()
    {
        return new PowerSupply(_peakConsumptionLoad);
    }
}