using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class ProcessorRepository : IRepository<IProcessor>
{
    private readonly Dictionary<string, IProcessor> _map = new()
    {
        {
            "Intel Core i5-10400F",
            new ProcessorBuilder().
                WithCoreFrequency(2.9).
                WithCoresAmount(6).
                WithProcessorSocket("LGA 1200").
                WithBuiltInVideoCardSupport(false).
                WithMemoryFrequency(3300).
                WithTdpAmount(65).
                WithPowerConsumption(77.2).
                Build()
        },
        {
            "Intel Core i5-12400",
            new ProcessorBuilder().
                WithCoreFrequency(2.5).
                WithCoresAmount(6).
                WithProcessorSocket("LGA 1700").
                WithBuiltInVideoCardSupport(false).
                WithMemoryFrequency(3333).
                WithTdpAmount(117).
                WithPowerConsumption(65).
                Build()
        },
    };

    public IProcessor GetByName(string detailName)
    {
        return _map[detailName];
    }
}