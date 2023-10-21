using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

public interface IWifiAdapterBuilder
{
    IWifiAdapterBuilder WithWifiStandardVersion(WifiVersion wifiVersion);

    IWifiAdapterBuilder WithBluetoothModuleSupport(bool bluetoothModuleSupport);

    IWifiAdapterBuilder WithPciVersion(PciController pciVersion);

    IWifiAdapterBuilder WithPowerConsumption(double powerAmount);

    IWifiAdapter Build();
}