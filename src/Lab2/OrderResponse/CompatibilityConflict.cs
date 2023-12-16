namespace Itmo.ObjectOrientedProgramming.Lab2.Order;

public abstract record CompatibilityConflict
{
    private CompatibilityConflict() { }

    public sealed record CompatibilitySuccess : CompatibilityConflict;

    public abstract record CriticalConflict : CompatibilityConflict;

    // ComputerCase
    public sealed record GraphicsCardNotFitInComputerCase : CriticalConflict;

    public sealed record MotherBoardNotFitInComputerCase : CriticalConflict;

    public sealed record CoolingSystemNotFitInComputerCase : CriticalConflict;

    // CoolingSystem
    public sealed record CoolingSystemAndProcessorDifferentSockets : CriticalConflict;

    // MotherBoard
    public sealed record InsufficientRamSlotsAmount : CriticalConflict;

    public sealed record DifferentDdrVersions : CriticalConflict;

    public sealed record MotherBoardAndRamMemoryDifferentMemoryFrequency : CriticalConflict;

    public sealed record MotherBoardAndProcessorDifferentMemoryFrequency : CriticalConflict;

    public sealed record MotherBoardAndProcessorDifferentSockets : CriticalConflict;

    public sealed record NetworkEquipmentConflictWithWifiAdapter : CriticalConflict;

    public sealed record InsufficientConnectionPortsAmount : CriticalConflict;

    public sealed record AbsenceOfVideoCore : CriticalConflict;

    public sealed record NoBiosSupportForProcessor : CriticalConflict;

    public abstract record Recommendation : CompatibilityConflict;

    // PowerSupply
    public sealed record InsufficientPowerSupply : Recommendation;

    public sealed record WarrantyDisclaimer : Recommendation;

    public sealed record ImpossibleToInstallOperatingSystem : Recommendation;
}