namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public abstract class Fuel : IResource
{
    protected int FuelTotalPrice { get; set; }

    public abstract void CalculatePrice(int fuelAmount);

    public int GetPrice()
    {
        return FuelTotalPrice;
    }
}