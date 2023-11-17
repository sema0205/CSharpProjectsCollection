using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public sealed class FileMoveBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveBuilder WithSourcePath(string value)
    {
        _sourcePath = value;
        return this;
    }

    public FileMoveBuilder WithDestinationPath(string value)
    {
        _destinationPath = value;
        return this;
    }

    public ArgumentContext.FileMoveCommandContext Build()
    {
        return new ArgumentContext.FileMoveCommandContext(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }
}