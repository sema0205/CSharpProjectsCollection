namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class FuelPlasma : Fuel
{
    private int FuelMarketPrice { get; } = MetricValues.MetricValues.PlasmaPrice;

    public override void CalculatePrice(int fuelAmount)
    {
        FuelTotalPrice = fuelAmount * FuelMarketPrice;
    }
}