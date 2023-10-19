using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class MotherBoardRepository : IRepository<IMotherBoard>
{
    private readonly Dictionary<string, IMotherBoard> _map = new()
    {
        {
            "GIGABYTE B760M",
            new MotherBoardBuilder().
                WithProcessorSocket("LGA 1700").
                WithPciLanes(1).
                WithSataPorts(3).
                WithChipSet(new List<double> { 3200, 3300, 3333, 3400, 3466, 3600, 3666, 3733 }, true).
                WithDdrType(new DdrType.Ddr4()).
                WithRamSlots(4).
                WithFormFactor(new MotherBoardFormFactor.MicroAtx()).
                WithBiosType(new BiosType.Uefi(6)).
                Build()
        },
        {
            "GIGABYTE H470M",
            new MotherBoardBuilder().
                WithProcessorSocket("LGA 1200").
                WithPciLanes(1).
                WithSataPorts(2).
                WithChipSet(new List<double> { 3200, 3300, 3333, 3400, 3466, 3600, 3666, 3733 }, true).
                WithDdrType(new DdrType.Ddr4()).
                WithRamSlots(2).
                WithFormFactor(new MotherBoardFormFactor.MicroAtx()).
                WithBiosType(new BiosType.Uefi(5)).
                Build()
        },
        {
            "AMD 1135",
            new MotherBoardBuilder().
                WithProcessorSocket("AM 4").
                WithPciLanes(1).
                WithSataPorts(2).
                WithChipSet(new List<double> { 3200, 3300, 3333, 3400, 3466, 3600, 3666, 3733 }, true).
                WithDdrType(new DdrType.Ddr4()).
                WithRamSlots(2).
                WithFormFactor(new MotherBoardFormFactor.MicroAtx()).
                WithBiosType(new BiosType.Uefi(5)).
                Build()
        },
    };

    public IMotherBoard GetByName(string detailName)
    {
        return _map[detailName];
    }
}