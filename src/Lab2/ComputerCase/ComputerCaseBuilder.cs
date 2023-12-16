using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase.Properties;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private readonly List<MotherBoardFormFactor> _motherBoardsFormFactors;
    private GraphicCardDimension? _maxGraphicCardSize;
    private ComputerCaseDimension? _size;

    public ComputerCaseBuilder()
    {
        _motherBoardsFormFactors = new List<MotherBoardFormFactor>();
    }

    public IComputerCaseBuilder WithMaxGraphicCardSize(double length, double width)
    {
        _maxGraphicCardSize = new GraphicCardDimension(length, width);
        return this;
    }

    public IComputerCaseBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor)
    {
        _motherBoardsFormFactors.Add(motherBoardFormFactor);
        return this;
    }

    public IComputerCaseBuilder WithComputerCaseSize(double length, double width, double height)
    {
        _size = new ComputerCaseDimension(length, width, height);
        return this;
    }

    public IComputerCase Build()
    {
        return new ComputerCase(
            _maxGraphicCardSize ?? throw new ArgumentNullException(nameof(_maxGraphicCardSize)),
            _motherBoardsFormFactors,
            _size ?? throw new ArgumentNullException(nameof(_size)));
    }
}