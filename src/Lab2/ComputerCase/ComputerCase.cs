using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase.Properties;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Order;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class ComputerCase : IComputerCase
{
    public ComputerCase(
        GraphicCardDimension maxGraphicCardSize,
        IEnumerable<MotherBoardFormFactor> motherBoardsFormFactors,
        ComputerCaseDimension size)
    {
        MaxGraphicCardSize = maxGraphicCardSize;
        MotherBoardsFormFactors = motherBoardsFormFactors.ToArray();
        Size = size;
    }

    public GraphicCardDimension MaxGraphicCardSize { get; }
    public IReadOnlyList<MotherBoardFormFactor> MotherBoardsFormFactors { get; }
    public ComputerCaseDimension Size { get; }

    public CompatibilityConflict Validate(IGraphicsCard computerDetail)
    {
        if (MaxGraphicCardSize.Length >= computerDetail.Size.Length && MaxGraphicCardSize.Width >= computerDetail.Size.Width)
            return new CompatibilityConflict.CompatibilitySuccess();
        return new CompatibilityConflict.GraphicsCardNotFitInComputerCase();
    }

    public CompatibilityConflict Validate(IMotherBoard computerDetail)
    {
        if (MotherBoardsFormFactors.Any(motherBoardFormFactor => motherBoardFormFactor == computerDetail.FormFactor))
            return new CompatibilityConflict.CompatibilitySuccess();

        return new CompatibilityConflict.MotherBoardNotFitInComputerCase();
    }

    public CompatibilityConflict Validate(ICoolingSystem computerDetail)
    {
        double computerCaseCapacity = Size.Length * Size.Width * Size.Height * 0.2;
        double coolingSystemCapacity = computerDetail.Size.Length * computerDetail.Size.Width * computerDetail.Size.Height;
        if (coolingSystemCapacity < computerCaseCapacity)
            return new CompatibilityConflict.CompatibilitySuccess();

        return new CompatibilityConflict.CoolingSystemNotFitInComputerCase();
    }
}