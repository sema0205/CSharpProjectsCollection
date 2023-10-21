using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class PowerSupplyRepository : IRepository<IPowerSupply>
{
    private readonly Dictionary<string, IPowerSupply> _map = new()
    {
        {
            "AeroCool Cylon",
            new PowerSupplyBuilder().
                WithPeakConsumptionLoad(500).
                Build()
        },
        {
            "AeroCool VX PLUS",
            new PowerSupplyBuilder().
                WithPeakConsumptionLoad(650).
                Build()
        },
    };

    public IPowerSupply GetByName(string detailName)
    {
        return _map[detailName];
    }
}