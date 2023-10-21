using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Selectors;

public class ResultSelector : IComparer<ModelInfo>
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

        return (first.Result, second.Result) switch
        {
            (DamageResult.Success, DamageResult.Failed) => -1,
            (DamageResult.Failed, DamageResult.Success) => 1,
            _ => 0,
        };
    }
}