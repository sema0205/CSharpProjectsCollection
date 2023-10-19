using System;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private WifiVersion? _wifiVersion;
    private bool _bluetoothSupport;
    private PciController? _pciVersion;
    private double _powerConsumption;

    public IWifiAdapterBuilder WithWifiStandardVersion(WifiVersion wifiVersion)
    {
        _wifiVersion = wifiVersion;
        return this;
    }

    public IWifiAdapterBuilder WithBluetoothModuleSupport(bool bluetoothModuleSupport)
    {
        _bluetoothSupport = bluetoothModuleSupport;
        return this;
    }

    public IWifiAdapterBuilder WithPciVersion(PciController pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWifiAdapterBuilder WithPowerConsumption(double powerAmount)
    {
        _powerConsumption = powerAmount;
        return this;
    }

    public IWifiAdapter Build()
    {
        return new WifiAdapter(
            _wifiVersion ?? throw new ArgumentNullException(nameof(_wifiVersion)),
            _bluetoothSupport,
            _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
            _powerConsumption);
    }
}