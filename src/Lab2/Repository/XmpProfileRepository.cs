using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class XmpProfileRepository : IRepository<IXmpProfile>
{
    private readonly Dictionary<string, IXmpProfile> _map = new()
    {
        {
            "XMP Profile 1",
            new XmpProfileBuilder().
                WithTimings(18, 18, 36, 54).
                WithVoltage(1.35).
                WithFrequency(3333).
                Build()
        },
        {
            "XMP Profile 2",
            new XmpProfileBuilder().
                WithTimings(14, 15, 35, 59).
                WithVoltage(1.25).
                WithFrequency(3200).
                Build()
        },
    };

    public IXmpProfile GetByName(string detailName)
    {
        return _map[detailName];
    }
}