using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase.Properties;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public interface IComputerCase : IValidator<IGraphicsCard>, IValidator<IMotherBoard>, IValidator<ICoolingSystem>
{
    public GraphicCardDimension MaxGraphicCardSize { get; }

    public IReadOnlyList<MotherBoardFormFactor> MotherBoardsFormFactors { get; }

    public ComputerCaseDimension Size { get; }
}