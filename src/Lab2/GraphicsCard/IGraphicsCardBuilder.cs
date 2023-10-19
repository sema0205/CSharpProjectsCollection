namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public interface IGraphicsCardBuilder
{
    IGraphicsCardBuilder WithGraphicCardSize(double length, double width);

    IGraphicsCardBuilder WithVideoMemoryAmount(int memoryAmount);

    IGraphicsCardBuilder WithPciVersion(PciController pciController);

    IGraphicsCardBuilder WithVideoChipFrequency(double videoChipFrequency);

    IGraphicsCardBuilder WithPowerConsumption(double powerConsumption);

    IGraphicsCard Build();
}