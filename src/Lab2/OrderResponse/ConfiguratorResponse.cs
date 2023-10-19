using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Order;

public abstract record ConfiguratorResponse
{
    private ConfiguratorResponse() { }

    public sealed record SuccessfulConfiguration(IComputer Computer, IReadOnlyList<CompatibilityConflict> Recommendations) : ConfiguratorResponse;

    public sealed record FailedConfiguration(IEnumerable<CompatibilityConflict> Conflicts) : ConfiguratorResponse;
}