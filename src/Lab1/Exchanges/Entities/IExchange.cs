using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exchanges;

public interface IExchange
{
    public int CheckStockPrice(IFuel fuel);
}