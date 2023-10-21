namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder WithPeakConsumptionLoad(double peakConsumptionLoad);

    IPowerSupply Build();
}