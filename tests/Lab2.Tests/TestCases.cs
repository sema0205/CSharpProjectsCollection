using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.HddDrive;
using Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Order;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCases
{
    [Fact]
    public void SuccessfulPcBuildWith()
    {
        IMotherBoard motherBoard = new MotherBoardRepository().GetByName("GIGABYTE H470M");
        IProcessor processor = new ProcessorRepository().GetByName("Intel Core i5-10400F");
        IBios bios = new BiosRepository().GetByName("UEFI 6");
        ICoolingSystem coolingSystem = new CoolingSystemRepository().GetByName("DEEPCOOL AG300");
        IRamMemory ramMemory = new RamMemoryRepository().GetByName("ADATA XPG GAMMIX D35");
        IGraphicsCard graphicsCard = new GraphicsCardRepository().GetByName("GeForce GTX 1650");
        ISsdDrive ssdDrive = new SsdDriveRepository().GetByName("Kingston A400");
        IComputerCase computerCase = new ComputerCaseRepository().GetByName("AeroCool Streak");
        IPowerSupply powerSupply = new PowerSupplyRepository().GetByName("AeroCool Cylon");

        ConfiguratorResponse configuratorResponse =
            new ComputerConfiguratorBuilder().
                WithMotherBoard(motherBoard).
                WithProcessor(processor).
                WithBios(bios).
                WithCoolingSystem(coolingSystem).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithGraphicsCard(graphicsCard).
                WithSsdDrive(ssdDrive).
                WithComputerCase(computerCase).
                WithPowerSupply(powerSupply).
                Build();

        Assert.True(configuratorResponse is ConfiguratorResponse.SuccessfulConfiguration);
        if (configuratorResponse is ConfiguratorResponse.SuccessfulConfiguration responseSuccess)
            Assert.True(responseSuccess.Recommendations.Count == 0);
    }

    [Fact]
    public void WarningOnExceedPowerLimit()
    {
        IMotherBoard motherBoard = new MotherBoardRepository().GetByName("GIGABYTE H470M");
        IProcessor processor = new ProcessorRepository().GetByName("Intel Core i5-10400F");
        IBios bios = new BiosRepository().GetByName("UEFI 6");
        ICoolingSystem coolingSystem = new CoolingSystemRepository().GetByName("DEEPCOOL AG300");
        IRamMemory ramMemory = new RamMemoryRepository().GetByName("ADATA XPG GAMMIX D35");
        IGraphicsCard graphicsCard = new GraphicsCardRepository().GetByName("GeForce GTX 1650");
        ISsdDrive ssdDrive = new SsdDriveRepository().GetByName("Kingston AK133");
        IComputerCase computerCase = new ComputerCaseRepository().GetByName("AeroCool Streak");
        IPowerSupply powerSupply = new PowerSupplyRepository().GetByName("AeroCool Cylon");

        ConfiguratorResponse configuratorResponse =
            new ComputerConfiguratorBuilder().
                WithMotherBoard(motherBoard).
                WithProcessor(processor).
                WithBios(bios).
                WithCoolingSystem(coolingSystem).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithGraphicsCard(graphicsCard).
                WithSsdDrive(ssdDrive).
                WithComputerCase(computerCase).
                WithPowerSupply(powerSupply).
                Build();

        Assert.True(configuratorResponse is ConfiguratorResponse.SuccessfulConfiguration);
        if (configuratorResponse is ConfiguratorResponse.SuccessfulConfiguration responseSuccess)
            Assert.Contains(new CompatibilityConflict.InsufficientPowerSupply(), responseSuccess.Recommendations);
    }

    [Fact]
    public void InsufficientHeatDissipationCapacity()
    {
        IMotherBoard motherBoard = new MotherBoardRepository().GetByName("GIGABYTE H470M");
        IProcessor processor = new ProcessorRepository().GetByName("Intel Core i5-10400F");
        IBios bios = new BiosRepository().GetByName("UEFI 6");
        ICoolingSystem coolingSystem = new CoolingSystemRepository().GetByName("TM-Cooling ST-14");
        IRamMemory ramMemory = new RamMemoryRepository().GetByName("ADATA XPG GAMMIX D35");
        IGraphicsCard graphicsCard = new GraphicsCardRepository().GetByName("GeForce GTX 1650");
        ISsdDrive ssdDrive = new SsdDriveRepository().GetByName("Kingston AK133");
        IComputerCase computerCase = new ComputerCaseRepository().GetByName("AeroCool Streak");
        IPowerSupply powerSupply = new PowerSupplyRepository().GetByName("AeroCool Cylon");

        ConfiguratorResponse configuratorResponse =
            new ComputerConfiguratorBuilder().
                WithMotherBoard(motherBoard).
                WithProcessor(processor).
                WithBios(bios).
                WithCoolingSystem(coolingSystem).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithGraphicsCard(graphicsCard).
                WithSsdDrive(ssdDrive).
                WithComputerCase(computerCase).
                WithPowerSupply(powerSupply).
                Build();

        Assert.True(configuratorResponse is ConfiguratorResponse.SuccessfulConfiguration);
        if (configuratorResponse is ConfiguratorResponse.SuccessfulConfiguration responseSuccess)
            Assert.Contains(new CompatibilityConflict.WarrantyDisclaimer(), responseSuccess.Recommendations);
    }

    [Fact]
    public void WrongMotherBoardAndProccesorSocket()
    {
        IMotherBoard motherBoard = new MotherBoardRepository().GetByName("AMD 1135");
        IProcessor processor = new ProcessorRepository().GetByName("Intel Core i5-10400F");
        IBios bios = new BiosRepository().GetByName("UEFI 6");
        ICoolingSystem coolingSystem = new CoolingSystemRepository().GetByName("TM-Cooling ST-14");
        IRamMemory ramMemory = new RamMemoryRepository().GetByName("ADATA XPG GAMMIX D35");
        IGraphicsCard graphicsCard = new GraphicsCardRepository().GetByName("GeForce GTX 1650");
        ISsdDrive ssdDrive = new SsdDriveRepository().GetByName("Kingston AK133");
        IComputerCase computerCase = new ComputerCaseRepository().GetByName("AeroCool Streak");
        IPowerSupply powerSupply = new PowerSupplyRepository().GetByName("AeroCool Cylon");

        ConfiguratorResponse configuratorResponse =
            new ComputerConfiguratorBuilder().
                WithMotherBoard(motherBoard).
                WithProcessor(processor).
                WithBios(bios).
                WithCoolingSystem(coolingSystem).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithGraphicsCard(graphicsCard).
                WithSsdDrive(ssdDrive).
                WithComputerCase(computerCase).
                WithPowerSupply(powerSupply).
                Build();

        Assert.True(configuratorResponse is ConfiguratorResponse.FailedConfiguration);
        if (configuratorResponse is ConfiguratorResponse.FailedConfiguration responseFailed)
            Assert.Contains(new CompatibilityConflict.MotherBoardAndProcessorDifferentSockets(), responseFailed.Conflicts);
    }

    [Fact]
    public void DifferentDdrVersions()
    {
        IMotherBoard motherBoard = new MotherBoardRepository().GetByName("AMD 1135");
        IProcessor processor = new ProcessorRepository().GetByName("Intel Core i5-10400F");
        IBios bios = new BiosRepository().GetByName("UEFI 6");
        ICoolingSystem coolingSystem = new CoolingSystemRepository().GetByName("TM-Cooling ST-14");
        IRamMemory ramMemory = new RamMemoryRepository().GetByName("Alata BGA Gaming");
        IGraphicsCard graphicsCard = new GraphicsCardRepository().GetByName("GeForce GTX 1650");
        ISsdDrive ssdDrive = new SsdDriveRepository().GetByName("Kingston AK133");
        IComputerCase computerCase = new ComputerCaseRepository().GetByName("AeroCool Streak");
        IPowerSupply powerSupply = new PowerSupplyRepository().GetByName("AeroCool Cylon");

        ConfiguratorResponse configuratorResponse =
            new ComputerConfiguratorBuilder().
                WithMotherBoard(motherBoard).
                WithProcessor(processor).
                WithBios(bios).
                WithCoolingSystem(coolingSystem).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithGraphicsCard(graphicsCard).
                WithSsdDrive(ssdDrive).
                WithComputerCase(computerCase).
                WithPowerSupply(powerSupply).
                Build();

        Assert.True(configuratorResponse is ConfiguratorResponse.FailedConfiguration);
        if (configuratorResponse is ConfiguratorResponse.FailedConfiguration responseFailed)
            Assert.Contains(new CompatibilityConflict.DifferentDdrVersions(), responseFailed.Conflicts);
    }

    [Fact]
    public void InsufficientRamSlotsAmount()
    {
        IMotherBoard motherBoard = new MotherBoardRepository().GetByName("GIGABYTE H470M");
        IProcessor processor = new ProcessorRepository().GetByName("Intel Core i5-10400F");
        IBios bios = new BiosRepository().GetByName("UEFI 6");
        ICoolingSystem coolingSystem = new CoolingSystemRepository().GetByName("TM-Cooling ST-14");
        IRamMemory ramMemory = new RamMemoryRepository().GetByName("ADATA XPG GAMMIX D35");
        IGraphicsCard graphicsCard = new GraphicsCardRepository().GetByName("GeForce GTX 1650");
        ISsdDrive ssdDrive = new SsdDriveRepository().GetByName("Kingston AK133");
        IComputerCase computerCase = new ComputerCaseRepository().GetByName("AeroCool Streak");
        IPowerSupply powerSupply = new PowerSupplyRepository().GetByName("AeroCool Cylon");

        ConfiguratorResponse configuratorResponse =
            new ComputerConfiguratorBuilder().
                WithMotherBoard(motherBoard).
                WithProcessor(processor).
                WithBios(bios).
                WithCoolingSystem(coolingSystem).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithRamMemory(ramMemory).
                WithGraphicsCard(graphicsCard).
                WithSsdDrive(ssdDrive).
                WithComputerCase(computerCase).
                WithPowerSupply(powerSupply).
                Build();

        Assert.True(configuratorResponse is ConfiguratorResponse.FailedConfiguration);
        if (configuratorResponse is ConfiguratorResponse.FailedConfiguration responseSuccess)
            Assert.Contains(new CompatibilityConflict.InsufficientRamSlotsAmount(), responseSuccess.Conflicts);
    }
}