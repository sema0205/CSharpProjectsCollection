namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessorBuilder
{
    IProcessorBuilder WithCoreFrequency(double coreFrequency);

    IProcessorBuilder WithCoresAmount(int coresAmount);

    IProcessorBuilder WithProcessorSocket(string processorSocket);

    IProcessorBuilder WithBuiltInVideoCardSupport(bool builtInVideoCardSupport);

    IProcessorBuilder WithMemoryFrequency(double memoryFrequency);

    IProcessorBuilder WithTdpAmount(double tdpAmount);

    IProcessorBuilder WithPowerConsumption(double powerConsumption);

    IProcessor Build();
}