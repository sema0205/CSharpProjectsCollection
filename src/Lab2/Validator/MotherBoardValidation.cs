using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validator;

public class MotherBoardValidation
{
    private readonly List<IRamMemory> _ramMemory;
    private readonly List<ISsdDrive> _ssdDrive;
    private readonly List<IHddDrive> _hddDrive;
    private readonly IMotherBoard _motherBoard;
    private readonly IProcessor _processor;
    private readonly IWifiAdapter? _wifiAdapter;

    public MotherBoardValidation(
        IEnumerable<IRamMemory>? ramMemory,
        IEnumerable<ISsdDrive>? ssdDrive,
        IEnumerable<IHddDrive>? hddDrive,
        IMotherBoard motherBoard,
        IProcessor processor,
        IWifiAdapter? wifiAdapter)
    {
        _ramMemory = new List<IRamMemory>();
        _ssdDrive = new List<ISsdDrive>();
        _hddDrive = new List<IHddDrive>();
        if (ramMemory is not null)
            _ramMemory = ramMemory.ToList();
        if (ssdDrive is not null)
            _ssdDrive = ssdDrive.ToList();
        if (hddDrive is not null)
            _hddDrive = hddDrive.ToList();
        _motherBoard = motherBoard;
        _processor = processor;
        _wifiAdapter = wifiAdapter;
    }

    public IReadOnlyList<CompatibilityConflict> Validate()
    {
        // MotherBoard Checks
        // TODO: add WIFI ADAPTER
        var recommendations = new List<CompatibilityConflict>();
        CompatibilityConflict ramMemory = _motherBoard.Validate(_ramMemory);
        if (ramMemory is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(ramMemory);

        CompatibilityConflict processor = _motherBoard.Validate(_processor);
        if (processor is not CompatibilityConflict.CompatibilitySuccess)
            recommendations.Add(processor);

        if (_wifiAdapter is not null)
        {
            CompatibilityConflict wifiAdapter = _motherBoard.Validate(_wifiAdapter);
            if (wifiAdapter is not CompatibilityConflict.CompatibilitySuccess)
                recommendations.Add(wifiAdapter);
        }

        if (_ssdDrive.Count == 0 && _hddDrive.Count == 0)
            recommendations.Add(new CompatibilityConflict.ImpossibleToInstallOperatingSystem());

        if (_ssdDrive.Count > 0)
        {
            CompatibilityConflict ssdDrive = _motherBoard.Validate(_ssdDrive);
            if (ssdDrive is not CompatibilityConflict.CompatibilitySuccess)
                recommendations.Add(ssdDrive);
        }

        if (_hddDrive.Count > 0)
        {
            CompatibilityConflict hddDrive = _motherBoard.Validate(_hddDrive);
            if (hddDrive is not CompatibilityConflict.CompatibilitySuccess)
                recommendations.Add(hddDrive);
        }

        return recommendations;
    }
}