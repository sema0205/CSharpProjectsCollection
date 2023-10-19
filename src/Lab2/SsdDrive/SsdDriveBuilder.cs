using System;
using Itmo.ObjectOrientedProgramming.Lab2.SsdDrive.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdDrive;

public class SsdDriveBuilder : ISsdDriveBuilder
{
    private SsdConnection? _connectionType;
    private int _memoryAmount;
    private double _maxWorkingSpeed;
    private double _powerConsumption;

    public ISsdDriveBuilder WithConnectionType(SsdConnection ssdConnection)
    {
        _connectionType = ssdConnection;
        return this;
    }

    public ISsdDriveBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public ISsdDriveBuilder WithMaxWorkingSpeed(double maxWorkingSpeed)
    {
        _maxWorkingSpeed = maxWorkingSpeed;
        return this;
    }

    public ISsdDriveBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsdDrive Build()
    {
        return new SsdDrive(
            _connectionType ?? throw new ArgumentNullException(nameof(_connectionType)),
            _memoryAmount,
            _maxWorkingSpeed,
            _powerConsumption);
    }
}