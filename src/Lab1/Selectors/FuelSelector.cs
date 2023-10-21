using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Selectors;

public class FuelSelector : IComparer<ModelInfo>
{
    public int Compare(ModelInfo? x, ModelInfo? y)
    {
        var first = new ModelInfo();
        var second = new ModelInfo();

        if (x is not null && y is not null)
        {
            first = x;
            second = y;
        }

        switch (first.Result)
        {
            case DamageResult.Success when second.Result is DamageResult.Failed:
                return -1;
            case DamageResult.Failed when second.Result is DamageResult.Success:
                return 1;
        }

        if (first.FuelSpend > second.FuelSpend)
            return 1;
        if (first.FuelSpend < second.FuelSpend)
            return -1;
        return 0;
    }
}