using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model;

public class ModelInfo
{
    public int TimeSpent { get; set; }

    public int FuelSpend { get; set; }

    public DamageResult Result { get; set; } = new Success.SuccessfulRoad();
}