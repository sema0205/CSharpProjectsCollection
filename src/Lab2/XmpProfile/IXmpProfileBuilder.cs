namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp;

public interface IXmpProfileBuilder
{
    IXmpProfileBuilder WithTimings(double casLatency, double rasPreCharge, double ras, double rc);

    IXmpProfileBuilder WithVoltage(double voltage);

    IXmpProfileBuilder WithFrequency(double frequency);

    IXmpProfile Build();
}