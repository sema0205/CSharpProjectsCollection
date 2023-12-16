using System;
using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsParseHandlers.ConnectionArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public class ConnectBuilder
{
    private string? _path;
    private string? _mode = "local";

    public ConnectBuilder WithPath(string value)
    {
        _path = value;
        return this;
    }

    public ConnectBuilder WithMode(string value)
    {
        _mode = value;
        return this;
    }

    public ConnectCommandContext Build()
    {
        return new ConnectCommandContext(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _mode ?? throw new ArgumentNullException(nameof(_mode)));
    }
}