using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

public interface IWifiAdapter
{
    public WifiVersion WifiVersion { get; }

    public bool BluetoothSupport { get; }

    public PciController PciVersion { get; }

    public double PowerConsumption { get; }
}