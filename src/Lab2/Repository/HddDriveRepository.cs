using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class HddDriveRepository : IRepository<IHddDrive>
{
    private readonly Dictionary<string, IHddDrive> _map = new()
    {
        {
            "Toshiba DT01",
            new HddDriveBuilder().
                WithMemoryAmount(1000).
                WithShaftSpeed(7200).
                WithPowerConsumption(6.4).
                Build()
        },
        {
            "Toshiba P300",
            new HddDriveBuilder().
                WithMemoryAmount(2000).
                WithShaftSpeed(7100).
                WithPowerConsumption(5.9).
                Build()
        },
    };

    public IHddDrive GetByName(string detailName)
    {
        return _map[detailName];
    }
}