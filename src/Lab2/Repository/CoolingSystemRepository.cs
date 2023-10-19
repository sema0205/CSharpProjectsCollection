using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class CoolingSystemRepository : IRepository<ICoolingSystem>
{
    private readonly Dictionary<string, ICoolingSystem> _map = new()
    {
        {
            "DEEPCOOL AG300",
            new CoolingSystemBuilder().
                WithCoolerSize(77, 119, 129).
                WithProcessorSocket("AM4").WithProcessorSocket("LGA 1200").WithProcessorSocket("LGA 1700").
                WithMaxTdpAmount(150).
                Build()
        },
        {
            "ID-Cooling SE-903-XT",
            new CoolingSystemBuilder().
                WithCoolerSize(65, 100, 123).
                WithProcessorSocket("AM5").WithProcessorSocket("LGA 1200").WithProcessorSocket("LGA 1700").
                WithMaxTdpAmount(130).
                Build()
        },
        {
            "TM-Cooling ST-14",
            new CoolingSystemBuilder().
                WithCoolerSize(65, 100, 123).
                WithProcessorSocket("AM5").WithProcessorSocket("LGA 1200").WithProcessorSocket("LGA 1700").
                WithMaxTdpAmount(60).
                Build()
        },
    };

    public ICoolingSystem GetByName(string detailName)
    {
        return _map[detailName];
    }
}