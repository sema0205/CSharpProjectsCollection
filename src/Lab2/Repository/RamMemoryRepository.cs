using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class RamMemoryRepository : IRepository<IRamMemory>
{
    private readonly Dictionary<string, IRamMemory> _map = new()
    {
        {
            "ADATA XPG GAMMIX D35",
            new RamMemoryBuilder().
                WithMemoryAmount(8).
                WithJedecConfiguration(1.35, 3200).
                WithXmpProfile(new Timings(18, 18, 36, 54), 1.35, 3200).
                WithFormFactor(new RamMemoryFormFactor.DImm()).
                WithDdrVersion(new DdrType.Ddr4()).
                WithPowerConsumption(0.6).
                Build()
        },
        {
            "ADATA XPG GAMMIX D20",
            new RamMemoryBuilder().
                WithMemoryAmount(8).
                WithJedecConfiguration(1.35, 3200).
                WithXmpProfile(new Timings(16, 16, 20, 54), 1.35, 3200).
                WithFormFactor(new RamMemoryFormFactor.DImm()).
                WithDdrVersion(new DdrType.Ddr4()).
                WithPowerConsumption(0.6).
                Build()
        },
        {
            "Alata BGA Gaming",
            new RamMemoryBuilder().
                WithMemoryAmount(8).
                WithJedecConfiguration(1.35, 3200).
                WithXmpProfile(new Timings(16, 16, 20, 54), 1.35, 3200).
                WithFormFactor(new RamMemoryFormFactor.DImm()).
                WithDdrVersion(new DdrType.Ddr3()).
                WithPowerConsumption(0.6).
                Build()
        },
    };

    public IRamMemory GetByName(string detailName)
    {
        return _map[detailName];
    }
}