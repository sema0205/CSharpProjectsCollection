using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public sealed class FileDeleteBuilder
{
    private string? _path;

    public FileDeleteBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public FileDeleteCommandContext Build()
    {
        return new FileDeleteCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}