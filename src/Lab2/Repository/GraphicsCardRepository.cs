using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class GraphicsCardRepository : IRepository<IGraphicsCard>
{
    private readonly Dictionary<string, IGraphicsCard> _map = new()
    {
        {
            "GeForce GTX 1650",
            new GraphicsCardBuilder().
                WithGraphicCardSize(200, 111).
                WithVideoMemoryAmount(4).
                WithPciVersion(new PciController.PciExpressV3()).
                WithVideoChipFrequency(1410).
                WithPowerConsumption(90).
                Build()
        },
        {
            "Palit GeForce RTX 4060",
            new GraphicsCardBuilder().
                WithGraphicCardSize(249.9, 123.5).
                WithVideoMemoryAmount(8).
                WithPciVersion(new PciController.PciExpressV4()).
                WithVideoChipFrequency(1830).
                WithPowerConsumption(115).
                Build()
        },
    };

    public IGraphicsCard GetByName(string detailName)
    {
        return _map[detailName];
    }
}