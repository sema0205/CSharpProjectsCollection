using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.HddDrive;

public class RamMemoryBuilder : IRamMemoryBuilder
{
    private int _memoryAmount;
    private List<JedecConfiguration> _jedecConfigurations;
    private List<XmpProfileInfo> _xmpProfiles;
    private RamMemoryFormFactor? _formFactor;
    private DdrType? _ddrVersion;
    private double _powerConsumption;

    public RamMemoryBuilder()
    {
        _jedecConfigurations = new List<JedecConfiguration>();
        _xmpProfiles = new List<XmpProfileInfo>();
    }

    public IRamMemoryBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public IRamMemoryBuilder WithJedecConfiguration(double voltage, double frequency)
    {
        _jedecConfigurations.Add(new JedecConfiguration(voltage, frequency));
        return this;
    }

    public IRamMemoryBuilder WithXmpProfile(Timings latencies, double voltage, double frequency)
    {
        _xmpProfiles.Add(new XmpProfileInfo(latencies, voltage, frequency));
        return this;
    }

    public IRamMemoryBuilder WithFormFactor(RamMemoryFormFactor ramMemoryFormFactor)
    {
        _formFactor = ramMemoryFormFactor;
        return this;
    }

    public IRamMemoryBuilder WithDdrVersion(DdrType ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRamMemoryBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRamMemory Build()
    {
        return new RamMemory(
            _memoryAmount,
            _jedecConfigurations,
            _xmpProfiles,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _powerConsumption);
    }
}