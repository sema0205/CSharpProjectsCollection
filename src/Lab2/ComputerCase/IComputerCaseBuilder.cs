using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder WithMaxGraphicCardSize(double length, double width);

    IComputerCaseBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor);

    IComputerCaseBuilder WithComputerCaseSize(double length, double width, double height);

    IComputerCase Build();
}