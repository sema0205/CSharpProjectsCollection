using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder WithProcessorSocket(string processorSocket);

    IMotherBoardBuilder WithPciLanes(int pciLanesAmount);

    IMotherBoardBuilder WithSataPorts(int sataPortsAmount);

    IMotherBoardBuilder WithChipSet(IEnumerable<double> supportedMemoryFrequencies, bool xmpSupport);

    IMotherBoardBuilder WithDdrType(DdrType supportedDdr);

    IMotherBoardBuilder WithRamSlots(int ramSlotsAmount);

    IMotherBoardBuilder WithFormFactor(MotherBoardFormFactor formFactor);

    IMotherBoardBuilder WithBiosType(BiosType bios);

    IMotherBoardBuilder WithWifiBuiltInSupport(bool wifiBuiltInSupport);

    IMotherBoard Build();
}