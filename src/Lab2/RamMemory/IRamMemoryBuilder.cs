using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public interface IRamMemoryBuilder
{
    IRamMemoryBuilder WithMemoryAmount(int memoryAmount);

    IRamMemoryBuilder WithJedecConfiguration(double voltage, double frequency);

    IRamMemoryBuilder WithXmpProfile(Timings latencies, double voltage, double frequency);

    IRamMemoryBuilder WithFormFactor(RamMemoryFormFactor ramMemoryFormFactor);

    IRamMemoryBuilder WithDdrVersion(DdrType ddrVersion);

    IRamMemoryBuilder WithPowerConsumption(double powerConsumption);

    IRamMemory Build();
}