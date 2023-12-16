using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Iterator;

public class CommandIterator : ICommandIterator
{
    private readonly List<string> _commandArguments;

    private int _currentElement;

    public CommandIterator(IEnumerable<string> commandArguments)
    {
        _commandArguments = commandArguments.ToList();
    }

    public string GetCurrent()
    {
        return _commandArguments[_currentElement];
    }

    public void MoveNext()
    {
        _currentElement++;
    }

    public bool HasMore()
    {
        return _currentElement < _commandArguments.Capacity;
    }
}