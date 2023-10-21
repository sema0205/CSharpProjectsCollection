namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public interface IGraphicsCard
{
    public GraphicCardDimension Size { get; }

    public int VideoMemoryAmount { get; }

    public PciController PciVersion { get; }

    public double VideoChipFrequency { get; }

    public double PowerConsumption { get; }
}