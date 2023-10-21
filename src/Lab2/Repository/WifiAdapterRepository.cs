using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class WifiAdapterRepository : IRepository<IWifiAdapter>
{
    private readonly Dictionary<string, IWifiAdapter> _map = new()
    {
        {
            "Mercusys MU6H",
            new WifiAdapterBuilder().
                WithWifiStandardVersion(new WifiVersion.N802()).
                WithWifiStandardVersion(new WifiVersion.Ac802()).
                WithBluetoothModuleSupport(true).
                WithPciVersion(new PciController.PciExpressV4()).
                WithPowerConsumption(6.5).
                Build()
        },
        {
            "TP-LINK TL-WN725N",
            new WifiAdapterBuilder().
                WithWifiStandardVersion(new WifiVersion.N802()).
                WithBluetoothModuleSupport(true).
                WithPciVersion(new PciController.PciExpressV4()).
                WithPowerConsumption(7.9).
                Build()
        },
    };

    public IWifiAdapter GetByName(string detailName)
    {
        return _map[detailName];
    }
}