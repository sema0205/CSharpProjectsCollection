using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public class TreeGoToBuilder
{
    private string? _path;

    public TreeGoToBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public ArgumentContext.TreeGoToCommandContext Build()
    {
        return new ArgumentContext.TreeGoToCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}