using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

public class WifiAdapter : IWifiAdapter
{
    public WifiAdapter(
        WifiVersion wifiVersion,
        bool bluetoothSupport,
        PciController pciVersion,
        double powerConsumption)
    {
        WifiVersion = wifiVersion;
        BluetoothSupport = bluetoothSupport;
        PciVersion = pciVersion;
        PowerConsumption = powerConsumption;
    }

    public WifiVersion WifiVersion { get; }
    public bool BluetoothSupport { get; }
    public PciController PciVersion { get; }
    public double PowerConsumption { get; }
}