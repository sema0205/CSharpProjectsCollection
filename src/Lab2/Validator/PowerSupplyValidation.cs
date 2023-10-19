using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validator;

public class PowerSupplyValidation
{
    private readonly IPowerSupply _powerSupply;
    private readonly List<IRamMemory> _ramMemory;
    private readonly List<ISsdDrive> _ssdDrive;
    private readonly List<IHddDrive> _hddDrive;
    private readonly IProcessor _processor;
    private readonly IWifiAdapter? _wifiAdapter;
    private readonly IGraphicsCard? _graphicsCard;

    public PowerSupplyValidation(
        IPowerSupply powerSupply,
        IEnumerable<IRamMemory> ramMemory,
        IEnumerable<ISsdDrive> ssdDrive,
        IEnumerable<IHddDrive> hddDrive,
        IProcessor processor,
        IWifiAdapter? wifiAdapter,
        IGraphicsCard? graphicsCard)
    {
        _ramMemory = new List<IRamMemory>();
        _ssdDrive = new List<ISsdDrive>();
        _hddDrive = new List<IHddDrive>();
        _powerSupply = powerSupply;
        _ramMemory = ramMemory.ToList();
        _ssdDrive = ssdDrive.ToList();
        _hddDrive = hddDrive.ToList();
        _processor = processor;
        _wifiAdapter = wifiAdapter;
        _graphicsCard = graphicsCard;
    }

    public IReadOnlyList<CompatibilityConflict> Validate()
    {
        var recommendations = new List<CompatibilityConflict>();
        double totalPowerConsumption = 0;

        if (_ssdDrive.Count > 0)
            totalPowerConsumption += _ssdDrive.Sum(ssdDrive => ssdDrive.PowerConsumption);
        if (_hddDrive.Count > 0)
            totalPowerConsumption += _hddDrive.Sum(ssdDrive => ssdDrive.PowerConsumption);

        totalPowerConsumption += _processor.PowerConsumption;
        totalPowerConsumption += _ramMemory.Sum(ramMemory => ramMemory.PowerConsumption);

        if (_graphicsCard is not null)
            totalPowerConsumption += _graphicsCard.PowerConsumption;
        if (_wifiAdapter is not null)
            totalPowerConsumption += _wifiAdapter.PowerConsumption;

        CompatibilityConflict powerSupply = _powerSupply.Validate(totalPowerConsumption);
        if (powerSupply is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(powerSupply);

        return recommendations;
    }
}