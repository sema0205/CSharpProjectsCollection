namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class FuelPlasma : IFuel
{
    public FuelPlasma(double amount)
    {
        Amount = amount;
    }

    public double Amount { get; }
}