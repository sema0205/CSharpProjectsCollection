using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public sealed class FileCopyBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyBuilder WithSourcePath(string value)
    {
        _sourcePath = value;
        return this;
    }

    public FileCopyBuilder WithDestinationPath(string value)
    {
        _destinationPath = value;
        return this;
    }

    public FileCopyCommandContext Build()
    {
        return new FileCopyCommandContext(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }
}