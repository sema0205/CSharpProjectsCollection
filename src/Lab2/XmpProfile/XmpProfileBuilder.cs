using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp;

public class XmpProfileBuilder : IXmpProfileBuilder
{
    private Timings? _latencies;
    private double _voltage;
    private double _frequency;

    public IXmpProfileBuilder WithTimings(double casLatency, double rasPreCharge, double ras, double rc)
    {
        _latencies = new Timings(casLatency, rasPreCharge, ras, rc);
        return this;
    }

    public IXmpProfileBuilder WithVoltage(double voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpProfileBuilder WithFrequency(double frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IXmpProfile Build()
    {
        return new XmpProfile(
            _latencies ?? throw new ArgumentNullException(nameof(_latencies)),
            _voltage,
            _frequency);
    }
}