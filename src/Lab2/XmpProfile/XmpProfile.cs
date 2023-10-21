namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp;

public class XmpProfile : IXmpProfile
{
    public XmpProfile(
        Timings latencies,
        double voltage,
        double frequency)
    {
        XmpProfileInfo = new XmpProfileInfo(latencies, voltage, frequency);
    }

    public XmpProfileInfo XmpProfileInfo { get; }
}