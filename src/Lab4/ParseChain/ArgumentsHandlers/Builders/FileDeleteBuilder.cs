using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public sealed class FileDeleteBuilder
{
    private string? _path;

    public FileDeleteBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public ArgumentContext.FileDeleteCommandContext Build()
    {
        return new ArgumentContext.FileDeleteCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}