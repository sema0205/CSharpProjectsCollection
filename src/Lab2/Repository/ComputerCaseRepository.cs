using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class ComputerCaseRepository : IRepository<IComputerCase>
{
    private readonly Dictionary<string, IComputerCase> _map = new()
    {
        {
            "AeroCool Streak",
            new ComputerCaseBuilder().
                WithMaxGraphicCardSize(335, 150).
                WithMotherBoardFormFactor(new MotherBoardFormFactor.MicroAtx()).
                WithMotherBoardFormFactor(new MotherBoardFormFactor.MiniItx()).
                WithComputerCaseSize(382.6, 170, 412.8).
                Build()
        },
        {
            "Cougar Duoface RGB",
            new ComputerCaseBuilder().
                WithMaxGraphicCardSize(330, 100).
                WithMotherBoardFormFactor(new MotherBoardFormFactor.MicroAtx()).
                WithMotherBoardFormFactor(new MotherBoardFormFactor.MiniItx()).
                WithComputerCaseSize(386, 230, 419).
                Build()
        },
    };

    public IComputerCase GetByName(string detailName)
    {
        return _map[detailName];
    }
}