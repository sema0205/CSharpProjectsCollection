using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class BiosRepository : IRepository<IBios>
{
    private readonly Dictionary<string, IBios> _map = new()
    {
        {
            "UEFI 6",
            new BiosBuilder().
                WithBiosType(new BiosType.Uefi(6)).
                WithSupportedProcessor("LGA 1200").
                Build()
        },
        {
            "UEFI 5",
            new BiosBuilder().
                WithBiosType(new BiosType.Uefi(5)).
                WithSupportedProcessor("LGA 1700").
                Build()
        },
    };

    public IBios GetByName(string detailName)
    {
        return _map[detailName];
    }
}