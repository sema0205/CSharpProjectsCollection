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
using Itmo.ObjectOrientedProgramming.Lab2.WIFIAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public interface IComputerConfiguratorBuilder
{
    IComputerConfiguratorBuilder WithMotherBoard(IMotherBoard motherBoard);

    IComputerConfiguratorBuilder WithProcessor(IProcessor processor);

    IComputerConfiguratorBuilder WithBios(IBios bios);

    IComputerConfiguratorBuilder WithCoolingSystem(ICoolingSystem coolingSystem);

    IComputerConfiguratorBuilder WithRamMemory(IRamMemory ramMemory);

    IComputerConfiguratorBuilder WithXmpProfile(IXmpProfile xmpProfile);

    IComputerConfiguratorBuilder WithGraphicsCard(IGraphicsCard graphicsCard);

    IComputerConfiguratorBuilder WithSsdDrive(ISsdDrive ssdDrive);

    IComputerConfiguratorBuilder WithHhdDrive(IHddDrive hddDrive);

    IComputerConfiguratorBuilder WithComputerCase(IComputerCase computerCase);

    IComputerConfiguratorBuilder WithPowerSupply(IPowerSupply powerSupply);

    IComputerConfiguratorBuilder WithWifiAdapter(IWifiAdapter wifiAdapter);

    ConfiguratorResponse Build();
}