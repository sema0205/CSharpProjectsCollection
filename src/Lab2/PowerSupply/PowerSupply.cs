using Itmo.ObjectOrientedProgramming.Lab2.Order;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupply : IPowerSupply
{
    public PowerSupply(double peakConsumptionLoad)
    {
        PeakConsumptionLoad = peakConsumptionLoad;
    }

    public double PeakConsumptionLoad { get; }

    public CompatibilityConflict Validate(double computerDetail)
    {
        if (PeakConsumptionLoad < computerDetail)
            return new CompatibilityConflict.InsufficientPowerSupply();

        return new CompatibilityConflict.CompatibilitySuccess();
    }
}