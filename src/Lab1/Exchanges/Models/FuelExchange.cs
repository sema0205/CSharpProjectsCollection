using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exchanges.Models;

public class FuelExchange : IExchange
{
    private const int PlasmaFuelPrice = 45;

    private const int GravitonFuelPrice = 65;

    public int CheckStockPrice(IFuel fuel)
    {
        if (fuel is FuelPlasma)
        {
            return (int)fuel.Amount * PlasmaFuelPrice;
        }

        if (fuel is FuelGraviton)
        {
            return (int)fuel.Amount * GravitonFuelPrice;
        }

        return 0;
    }
}