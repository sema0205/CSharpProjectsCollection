using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public interface IComputer
{
    IMotherBoard MotherBoard { get; }

    IProcessor Processor { get; }

    IBios Bios { get; }

    ICoolingSystem CoolingSystem { get; }

    IReadOnlyList<IRamMemory> RamMemory { get; }

    IReadOnlyList<IXmpProfile> XmpProfiles { get; }

    IGraphicsCard? GraphicsCard { get; }

    IReadOnlyList<ISsdDrive> SsdDrive { get; }

    IReadOnlyList<IHddDrive> HddDrive { get; }

    IComputerCase ComputerCase { get; }

    IPowerSupply PowerSupply { get; }

    IWifiAdapter? WifiAdapter { get; }
}