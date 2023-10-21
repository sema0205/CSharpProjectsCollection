using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validator;

public class ProcessorValidation
{
    private readonly IProcessor _processor;
    private readonly IBios _bios;
    private readonly ICoolingSystem _coolingSystem;
    private readonly IGraphicsCard? _graphicsCard;

    public ProcessorValidation(
        IProcessor processor,
        IBios bios,
        ICoolingSystem coolingSystem,
        IGraphicsCard? graphicsCard)
    {
        _processor = processor;
        _bios = bios;
        _coolingSystem = coolingSystem;
        _graphicsCard = graphicsCard;
    }

    public IReadOnlyList<CompatibilityConflict> Validate()
    {
        var recommendations = new List<CompatibilityConflict>();
        CompatibilityConflict bios = _bios.Validate(_processor);
        if (bios is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(bios);

        CompatibilityConflict coolingSystem = _coolingSystem.Validate(_processor);
        if (coolingSystem is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(coolingSystem);

        if (!_processor.BuiltInVideoCardSupport && _graphicsCard is null)
            recommendations.Add(new CompatibilityConflict.AbsenceOfVideoCore());

        return recommendations;
    }
}