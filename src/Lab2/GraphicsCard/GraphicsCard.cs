namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public class GraphicsCard : IGraphicsCard
{
    public GraphicsCard(
        GraphicCardDimension size,
        int videoMemoryAmount,
        PciController pciVersion,
        double videoChipFrequency,
        double powerConsumption)
    {
        Size = size;
        VideoMemoryAmount = videoMemoryAmount;
        PciVersion = pciVersion;
        VideoChipFrequency = videoChipFrequency;
        PowerConsumption = powerConsumption;
    }

    public GraphicCardDimension Size { get; }
    public int VideoMemoryAmount { get; }
    public PciController PciVersion { get; }
    public double VideoChipFrequency { get; }
    public double PowerConsumption { get; }
}