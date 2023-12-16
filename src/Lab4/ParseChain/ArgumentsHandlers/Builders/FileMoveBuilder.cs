using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

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

    public FileMoveCommandContext Build()
    {
        return new FileMoveCommandContext(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }
}