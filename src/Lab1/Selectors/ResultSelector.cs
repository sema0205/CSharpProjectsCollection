using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Selectors;

public static class ResultSelector
{
    public static int CompareByResult(ModelInfo first, ModelInfo second)
    {
        return first.Result switch
        {
            Success when second.Result is Failed => -1,
            Failed when second.Result is Success => 1,
            _ => 0,
        };
    }
}