using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Order;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validator;

public class ComputerCaseValidation
{
    private readonly IComputerCase _computerCase;
    private readonly IMotherBoard _motherBoard;
    private readonly ICoolingSystem _coolingSystem;
    private readonly IGraphicsCard? _graphicsCard;

    public ComputerCaseValidation(
        IComputerCase computerCase,
        IMotherBoard motherBoard,
        ICoolingSystem coolingSystem,
        IGraphicsCard? graphicsCard)
    {
        _computerCase = computerCase;
        _motherBoard = motherBoard;
        _coolingSystem = coolingSystem;
        _graphicsCard = graphicsCard;
    }

    public IReadOnlyList<CompatibilityConflict> Validate()
    {
        var recommendations = new List<CompatibilityConflict>();
        if (_graphicsCard is not null)
        {
            CompatibilityConflict computerCaseGraphicsCard = _computerCase.Validate(_graphicsCard);
            if (computerCaseGraphicsCard is not CompatibilityConflict.CompatibilitySuccess)
                recommendations.Add(computerCaseGraphicsCard);
        }

        CompatibilityConflict computerCaseMotherBoard = _computerCase.Validate(_motherBoard);
        if (computerCaseMotherBoard is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(computerCaseMotherBoard);

        CompatibilityConflict computerCaseCoolingSystem = _computerCase.Validate(_coolingSystem);
        if (computerCaseCoolingSystem is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(computerCaseCoolingSystem);

        return recommendations;
    }
}