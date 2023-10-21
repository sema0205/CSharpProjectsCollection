using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private CoolerDimension? _size;
    private List<string> _processorSocket;
    private double _maxTdpAmount;

    public CoolingSystemBuilder()
    {
        _processorSocket = new List<string>();
    }

    public ICoolingSystemBuilder WithCoolerSize(double length, double width, double height)
    {
        _size = new CoolerDimension(length, width, height);
        return this;
    }

    public ICoolingSystemBuilder WithProcessorSocket(string processorSocket)
    {
        _processorSocket.Add(processorSocket);
        return this;
    }

    public ICoolingSystemBuilder WithMaxTdpAmount(double maxTdpAmount)
    {
        _maxTdpAmount = maxTdpAmount;
        return this;
    }

    public ICoolingSystem Build()
    {
        return new CoolingSystem(
            _size ?? throw new ArgumentNullException(nameof(_size)),
            _processorSocket ?? throw new ArgumentNullException(nameof(_processorSocket)),
            _maxTdpAmount);
    }
}