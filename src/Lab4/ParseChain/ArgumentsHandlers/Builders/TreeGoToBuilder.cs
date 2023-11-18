using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public class TreeGoToBuilder
{
    private string? _path;

    public TreeGoToBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public TreeGoToCommandContext Build()
    {
        return new TreeGoToCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}