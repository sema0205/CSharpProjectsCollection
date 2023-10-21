namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder WithCoolerSize(double length, double width, double height);

    ICoolingSystemBuilder WithProcessorSocket(string processorSocket);

    ICoolingSystemBuilder WithMaxTdpAmount(double maxTdpAmount);

    ICoolingSystem Build();
}