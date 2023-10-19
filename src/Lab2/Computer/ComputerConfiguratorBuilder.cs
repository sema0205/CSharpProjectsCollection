using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Validator;
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public class ComputerConfiguratorBuilder : IComputerConfiguratorBuilder
{
    private readonly List<IRamMemory> _ramMemory;
    private readonly List<ISsdDrive> _ssdDrive;
    private readonly List<IHddDrive> _hddDrive;
    private readonly List<IXmpProfile> _xmpProfiles;
    private IMotherBoard? _motherBoard;
    private IProcessor? _processor;
    private IBios? _bios;
    private ICoolingSystem? _coolingSystem;
    private IGraphicsCard? _graphicsCard;
    private IComputerCase? _computerCase;
    private IPowerSupply? _powerSupply;
    private IWifiAdapter? _wifiAdapter;

    public ComputerConfiguratorBuilder()
    {
        _ramMemory = new List<IRamMemory>();
        _ssdDrive = new List<ISsdDrive>();
        _hddDrive = new List<IHddDrive>();
        _xmpProfiles = new List<IXmpProfile>();
    }

    public IComputerConfiguratorBuilder WithMotherBoard(IMotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerConfiguratorBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IComputerConfiguratorBuilder WithProcessor(IProcessor processor)
    {
        _processor = processor;
        return this;
    }

    public IComputerConfiguratorBuilder WithComputerCase(IComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IComputerConfiguratorBuilder WithCoolingSystem(ICoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IComputerConfiguratorBuilder WithGraphicsCard(IGraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IComputerConfiguratorBuilder WithXmpProfile(IXmpProfile xmpProfile)
    {
        _xmpProfiles.Add(xmpProfile);
        return this;
    }

    public IComputerConfiguratorBuilder WithHhdDrive(IHddDrive hddDrive)
    {
        _hddDrive.Add(hddDrive);
        return this;
    }

    public IComputerConfiguratorBuilder WithPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerConfiguratorBuilder WithRamMemory(IRamMemory ramMemory)
    {
        _ramMemory.Add(ramMemory);
        return this;
    }

    public IComputerConfiguratorBuilder WithSsdDrive(ISsdDrive ssdDrive)
    {
        _ssdDrive.Add(ssdDrive);
        return this;
    }

    public IComputerConfiguratorBuilder WithWifiAdapter(IWifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public ConfiguratorResponse Build()
    {
        var recommendations = new List<CompatibilityConflict>();
        var computer = new Computer.Computer(
            _motherBoard ?? throw new ArgumentNullException(nameof(_motherBoard)),
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _coolingSystem ?? throw new ArgumentNullException(nameof(_coolingSystem)),
            _ramMemory,
            _xmpProfiles,
            _graphicsCard,
            _ssdDrive,
            _hddDrive,
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)),
            _powerSupply ?? throw new ArgumentNullException(nameof(_powerSupply)),
            _wifiAdapter);

        var motherBoardValidation = new MotherBoardValidation(
            _ramMemory,
            _ssdDrive,
            _hddDrive,
            _motherBoard,
            _processor,
            _wifiAdapter);
        recommendations.AddRange(motherBoardValidation.Validate());

        var processorValidation = new ProcessorValidation(
            _processor,
            _bios,
            _coolingSystem,
            _graphicsCard);
        recommendations.AddRange(processorValidation.Validate());

        var powerSupply = new PowerSupplyValidation(
            _powerSupply,
            _ramMemory,
            _ssdDrive,
            _hddDrive,
            _processor,
            _wifiAdapter,
            _graphicsCard);
        recommendations.AddRange(powerSupply.Validate());

        var computerCase = new ComputerCaseValidation(
            _computerCase,
            _motherBoard,
            _coolingSystem,
            _graphicsCard);
        recommendations.AddRange(computerCase.Validate());

        bool criticalConflicts = recommendations.Any(conflict => conflict is CompatibilityConflict.CriticalConflict);
        if (criticalConflicts)
            return new ConfiguratorResponse.FailedConfiguration(recommendations);

        return new ConfiguratorResponse.SuccessfulConfiguration(computer, recommendations);
    }
}