namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public interface IResource
{
    public void CalculatePrice(int fuelAmount);

    public int GetPrice();
}