using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public sealed class FileShowBuilder
{
    private string? _path;
    private string? _mode = "console";

    public FileShowBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public FileShowBuilder WithMode(string value)
    {
        _mode = value;
        return this;
    }

    public ArgumentContext.FileShowCommandContext Build()
    {
        return new ArgumentContext.FileShowCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _mode ?? throw new ArgumentNullException(nameof(_mode)));
    }
}