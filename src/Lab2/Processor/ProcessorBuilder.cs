using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class ProcessorBuilder : IProcessorBuilder
{
    private readonly List<double> _memoryFrequency;
    private double _coreFrequency;
    private int _coresAmount;
    private string? _processorSocket;
    private bool _builtInVideoCardSupport;
    private double _tdpAmount;
    private double _powerConsumption;

    public ProcessorBuilder()
    {
        _memoryFrequency = new List<double>();
    }

    public IProcessorBuilder WithCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public IProcessorBuilder WithCoresAmount(int coresAmount)
    {
        _coresAmount = coresAmount;
        return this;
    }

    public IProcessorBuilder WithProcessorSocket(string processorSocket)
    {
        _processorSocket = processorSocket;
        return this;
    }

    public IProcessorBuilder WithBuiltInVideoCardSupport(bool builtInVideoCardSupport)
    {
        _builtInVideoCardSupport = builtInVideoCardSupport;
        return this;
    }

    public IProcessorBuilder WithMemoryFrequency(double memoryFrequency)
    {
        _memoryFrequency.Add(memoryFrequency);
        return this;
    }

    public IProcessorBuilder WithTdpAmount(double tdpAmount)
    {
        _tdpAmount = tdpAmount;
        return this;
    }

    public IProcessorBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IProcessor Build()
    {
        return new Processor(
            _coreFrequency,
            _coresAmount,
            _processorSocket ?? throw new ArgumentNullException(nameof(_processorSocket)),
            _builtInVideoCardSupport,
            _memoryFrequency,
            _tdpAmount,
            _powerConsumption);
    }
}