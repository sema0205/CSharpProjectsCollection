using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Validator;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

public interface IMotherBoard :
    IValidator<IProcessor>,
    IValidator<IReadOnlyList<IRamMemory>>,
    IValidator<IWifiAdapter>,
    IValidator<IReadOnlyList<ISsdDrive>>,
    IValidator<IReadOnlyList<IHddDrive>>
{
    public string ProcessorSocket { get; }

    public int PciLanesAmount { get; }

    public int SataPortsAmount { get; }

    public ChipSet ChipSet { get; }

    public DdrType SupportedDdr { get; }

    public int RamSlotsAmount { get; }

    public MotherBoardFormFactor FormFactor { get; }

    public BiosType Bios { get; }

    public bool WifiBuiltInSupport { get; }
}