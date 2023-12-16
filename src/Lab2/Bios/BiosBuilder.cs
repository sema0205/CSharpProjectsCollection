using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public class BiosBuilder : IBiosBuilder
{
    private readonly List<string> _supportedProcessors;
    private BiosType? _biosType;

    public BiosBuilder()
    {
        _supportedProcessors = new List<string>();
    }

    public IBiosBuilder WithBiosType(BiosType biosType)
    {
        _biosType = biosType;
        return this;
    }

    public IBiosBuilder WithSupportedProcessor(string supportedProcessor)
    {
        _supportedProcessors.Add(supportedProcessor);
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            _biosType ?? throw new ArgumentNullException(nameof(_biosType)),
            _supportedProcessors);
    }
}