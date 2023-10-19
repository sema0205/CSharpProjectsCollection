using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public class GraphicsCardBuilder : IGraphicsCardBuilder
{
    private GraphicCardDimension? _size;
    private int _videoMemoryAmount;
    private PciController? _pciVersion;
    private double _videoChipFrequency;
    private double _powerConsumption;

    public IGraphicsCardBuilder WithGraphicCardSize(double length, double width)
    {
        _size = new GraphicCardDimension(length, width);
        return this;
    }

    public IGraphicsCardBuilder WithVideoMemoryAmount(int memoryAmount)
    {
        _videoMemoryAmount = memoryAmount;
        return this;
    }

    public IGraphicsCardBuilder WithPciVersion(PciController pciController)
    {
        _pciVersion = pciController;
        return this;
    }

    public IGraphicsCardBuilder WithVideoChipFrequency(double videoChipFrequency)
    {
        _videoChipFrequency = videoChipFrequency;
        return this;
    }

    public IGraphicsCardBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IGraphicsCard Build()
    {
        return new GraphicsCard(
            _size ?? throw new ArgumentNullException(nameof(_size)),
            _videoMemoryAmount,
            _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
            _videoChipFrequency,
            _powerConsumption);
    }
}