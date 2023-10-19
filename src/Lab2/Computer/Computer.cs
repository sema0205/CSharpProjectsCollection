using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class Computer : IComputer, IComputerConfiguratorBuilderDirector
{
    internal Computer(
        IMotherBoard motherBoard,
        IProcessor processor,
        IBios bios,
        ICoolingSystem coolingSystem,
        IEnumerable<IRamMemory> ramMemory,
        IEnumerable<IXmpProfile>? xmpProfiles,
        IGraphicsCard? graphicsCard,
        IEnumerable<ISsdDrive>? ssdDrive,
        IEnumerable<IHddDrive>? hddDrive,
        IComputerCase computerCase,
        IPowerSupply powerSupply,
        IWifiAdapter? wifiAdapter)
    {
        XmpProfiles = new List<IXmpProfile>();
        SsdDrive = new List<ISsdDrive>();
        HddDrive = new List<IHddDrive>();
        MotherBoard = motherBoard;
        Processor = processor;
        Bios = bios;
        CoolingSystem = coolingSystem;
        RamMemory = ramMemory.ToArray();
        GraphicsCard = graphicsCard;
        ComputerCase = computerCase;
        PowerSupply = powerSupply;
        if (xmpProfiles is not null)
            XmpProfiles = xmpProfiles.ToArray();
        if (ssdDrive is not null)
            SsdDrive = ssdDrive.ToArray();
        if (hddDrive is not null)
            HddDrive = hddDrive.ToArray();
        if (wifiAdapter is not null)
            WifiAdapter = wifiAdapter;
    }

    public IMotherBoard MotherBoard { get; }
    public IProcessor Processor { get; }
    public IBios Bios { get; }
    public ICoolingSystem CoolingSystem { get; }
    public IReadOnlyList<IRamMemory> RamMemory { get; }
    public IReadOnlyList<IXmpProfile> XmpProfiles { get; }
    public IGraphicsCard? GraphicsCard { get; }
    public IReadOnlyList<ISsdDrive> SsdDrive { get; }
    public IReadOnlyList<IHddDrive> HddDrive { get; }
    public IComputerCase ComputerCase { get; }
    public IPowerSupply PowerSupply { get; }
    public IWifiAdapter? WifiAdapter { get; }

    public IComputerConfiguratorBuilder Direct(IComputerConfiguratorBuilder builder)
    {
        builder.WithMotherBoard(MotherBoard);
        builder.WithProcessor(Processor);
        builder.WithBios(Bios);
        builder.WithCoolingSystem(CoolingSystem);

        foreach (IRamMemory ramMemory in RamMemory)
        {
            builder.WithRamMemory(ramMemory);
        }

        foreach (IXmpProfile xmpProfile in XmpProfiles)
        {
            builder.WithXmpProfile(xmpProfile);
        }

        if (GraphicsCard is not null)
            builder.WithGraphicsCard(GraphicsCard);

        foreach (ISsdDrive ssdDrive in SsdDrive)
        {
            builder.WithSsdDrive(ssdDrive);
        }

        foreach (IHddDrive hddDrive in HddDrive)
        {
            builder.WithHhdDrive(hddDrive);
        }

        builder.WithComputerCase(ComputerCase);
        builder.WithPowerSupply(PowerSupply);
        if (WifiAdapter is not null)
            builder.WithWifiAdapter(WifiAdapter);

        return builder;
    }
}