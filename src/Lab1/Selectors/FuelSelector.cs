using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Selectors;

public static class FuelSelector
{
    public static int CompareByFuelUsage(ModelInfo first, ModelInfo second)
    {
        switch (first.Result)
        {
            case Success when second.Result is Failed:
                return -1;
            case Failed when second.Result is Success:
                return 1;
        }

        if (first.FuelSpend > second.FuelSpend)
            return 1;
        if (first.FuelSpend < second.FuelSpend)
            return -1;
        return 0;
    }
}