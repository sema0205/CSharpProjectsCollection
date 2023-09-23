namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class FuelGraviton : Fuel
{
    private int FuelMarketPrice { get; } = MetricValues.MetricValues.GravitonPrice;

    public override void CalculatePrice(int fuelAmount)
    {
        FuelTotalPrice = fuelAmount * FuelMarketPrice;
    }
}