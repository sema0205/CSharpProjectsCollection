using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public sealed class FileRenameBuilder
{
    private string? _path;
    private string? _newName;

    public FileRenameBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public FileRenameBuilder WithNewName(string value)
    {
        _newName = value;
        return this;
    }

    public FileRenameCommandContext Build()
    {
        return new FileRenameCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _newName ?? throw new ArgumentNullException(nameof(_newName)));
    }
}