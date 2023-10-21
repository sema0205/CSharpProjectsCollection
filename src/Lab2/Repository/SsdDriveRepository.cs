using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class SsdDriveRepository : IRepository<ISsdDrive>
{
    private readonly Dictionary<string, ISsdDrive> _map = new()
    {
        {
            "Kingston A400",
            new SsdDriveBuilder().
                WithConnectionType(new SsdConnection.Sata()).
                WithMemoryAmount(480).
                WithMaxWorkingSpeed(500).
                WithPowerConsumption(1.53).
                Build()
        },
        {
            "Kingston NV2",
            new SsdDriveBuilder().
                WithConnectionType(new SsdConnection.PciExpress()).
                WithMemoryAmount(500).
                WithMaxWorkingSpeed(3500).
                WithPowerConsumption(1.6).
                Build()
        },
        {
            "Kingston AK133",
            new SsdDriveBuilder().
                WithConnectionType(new SsdConnection.PciExpress()).
                WithMemoryAmount(500).
                WithMaxWorkingSpeed(3500).
                WithPowerConsumption(500).
                Build()
        },
    };

    public ISsdDrive GetByName(string detailName)
    {
        return _map[detailName];
    }
}