namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class FuelGraviton : IFuel
{
    public FuelGraviton(double amount)
    {
        Amount = amount;
    }

    public double Amount { get; }
}