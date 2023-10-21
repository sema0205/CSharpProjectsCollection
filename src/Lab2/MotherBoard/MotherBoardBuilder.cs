using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private string? _processorSocket;
    private int _pciLanesAmount;
    private int _sataPortsAmount;
    private ChipSet? _chipSet;
    private DdrType? _supportedDdr;
    private int _ramSlotsAmount;
    private MotherBoardFormFactor? _formFactor;
    private BiosType? _bios;
    private bool _wifiBuiltInSupport;

    public IMotherBoardBuilder WithProcessorSocket(string processorSocket)
    {
        _processorSocket = processorSocket;
        return this;
    }

    public IMotherBoardBuilder WithPciLanes(int pciLanesAmount)
    {
        _pciLanesAmount = pciLanesAmount;
        return this;
    }

    public IMotherBoardBuilder WithSataPorts(int sataPortsAmount)
    {
        _sataPortsAmount = sataPortsAmount;
        return this;
    }

    public IMotherBoardBuilder WithChipSet(IEnumerable<double> supportedMemoryFrequencies, bool xmpSupport)
    {
        _chipSet = new ChipSet(supportedMemoryFrequencies, xmpSupport);
        return this;
    }

    public IMotherBoardBuilder WithDdrType(DdrType supportedDdr)
    {
        _supportedDdr = supportedDdr;
        return this;
    }

    public IMotherBoardBuilder WithRamSlots(int ramSlotsAmount)
    {
        _ramSlotsAmount = ramSlotsAmount;
        return this;
    }

    public IMotherBoardBuilder WithFormFactor(MotherBoardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder WithBiosType(BiosType bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherBoardBuilder WithWifiBuiltInSupport(bool wifiBuiltInSupport)
    {
        _wifiBuiltInSupport = wifiBuiltInSupport;
        return this;
    }

    public IMotherBoard Build()
    {
        return new MotherBoard(
            _processorSocket ?? throw new ArgumentNullException(nameof(_processorSocket)),
            _pciLanesAmount,
            _sataPortsAmount,
            _chipSet ?? throw new ArgumentNullException(nameof(_chipSet)),
            _supportedDdr ?? throw new ArgumentNullException(nameof(_supportedDdr)),
            _ramSlotsAmount,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _wifiBuiltInSupport);
    }
}