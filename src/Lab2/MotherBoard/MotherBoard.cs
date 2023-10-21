using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

public class MotherBoard : IMotherBoard
{
    public MotherBoard(
        string processorSocket,
        int pciLanesAmount,
        int sataPortsAmount,
        ChipSet chipSet,
        DdrType supportedDdr,
        int ramSlotsAmount,
        MotherBoardFormFactor formFactor,
        BiosType bios,
        bool wifiBuiltInSupport)
    {
        ProcessorSocket = processorSocket;
        PciLanesAmount = pciLanesAmount;
        SataPortsAmount = sataPortsAmount;
        ChipSet = chipSet;
        SupportedDdr = supportedDdr;
        RamSlotsAmount = ramSlotsAmount;
        FormFactor = formFactor;
        Bios = bios;
        WifiBuiltInSupport = wifiBuiltInSupport;
    }

    public string ProcessorSocket { get; }
    public int PciLanesAmount { get; }
    public int SataPortsAmount { get; }
    public ChipSet ChipSet { get; }
    public DdrType SupportedDdr { get; }
    public int RamSlotsAmount { get; }
    public MotherBoardFormFactor FormFactor { get; }
    public BiosType Bios { get; }

    public bool WifiBuiltInSupport { get; }

    public CompatibilityConflict Validate(IReadOnlyList<IRamMemory> computerDetail)
    {
        if (computerDetail.Count > RamSlotsAmount)
            return new CompatibilityConflict.InsufficientRamSlotsAmount();

        foreach (IRamMemory ramMemory in computerDetail)
        {
            if (ramMemory.DdrVersion != SupportedDdr)
                return new CompatibilityConflict.DifferentDdrVersions();

            bool isCommonFrequency = false;
            foreach (JedecConfiguration jedecConfiguration in ramMemory.JedecConfigurations)
            {
                if (ChipSet.MemoryFrequencies.Any(processorFrequency => processorFrequency == jedecConfiguration.Frequency))
                    isCommonFrequency = true;

                if (isCommonFrequency)
                    break;
            }

            if (!isCommonFrequency)
                return new CompatibilityConflict.MotherBoardAndRamMemoryDifferentMemoryFrequency();
        }

        return new CompatibilityConflict.CompatibilitySuccess();
    }

    public CompatibilityConflict Validate(IProcessor computerDetail)
    {
        if (computerDetail.ProcessorSocket != ProcessorSocket)
            return new CompatibilityConflict.MotherBoardAndProcessorDifferentSockets();

        bool isCommonFrequency = false;
        foreach (double memoryFrequencyMotherBoard in ChipSet.MemoryFrequencies)
        {
            if (computerDetail.MemoryFrequency.Any(processorFrequency => processorFrequency == memoryFrequencyMotherBoard))
                isCommonFrequency = true;

            if (isCommonFrequency)
                break;
        }

        if (!isCommonFrequency)
            return new CompatibilityConflict.MotherBoardAndProcessorDifferentMemoryFrequency();

        return new CompatibilityConflict.CompatibilitySuccess();
    }

    public CompatibilityConflict Validate(IWifiAdapter computerDetail)
    {
        if (WifiBuiltInSupport)
            return new CompatibilityConflict.NetworkEquipmentConflictWithWifiAdapter();

        return new CompatibilityConflict.CompatibilitySuccess();
    }

    public CompatibilityConflict Validate(IReadOnlyList<ISsdDrive> computerDetail)
    {
        int sataPorts = 0;
        int pciLanes = 0;

        foreach (ISsdDrive ssdDrive in computerDetail)
        {
            switch (ssdDrive.ConnectionType)
            {
                case SsdConnection.Sata:
                    ++sataPorts;
                    break;
                case SsdConnection.PciExpress:
                    ++pciLanes;
                    break;
            }
        }

        if (sataPorts > SataPortsAmount || pciLanes > PciLanesAmount)
            return new CompatibilityConflict.InsufficientConnectionPortsAmount();

        return new CompatibilityConflict.CompatibilitySuccess();
    }

    public CompatibilityConflict Validate(IReadOnlyList<IHddDrive> computerDetail)
    {
        if (SataPortsAmount < computerDetail.Count)
            return new CompatibilityConflict.InsufficientConnectionPortsAmount();

        return new CompatibilityConflict.CompatibilitySuccess();
    }
}