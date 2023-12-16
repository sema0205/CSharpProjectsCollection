namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Iterator;

public interface ICommandIterator
{
    string GetCurrent();

    void MoveNext();

    bool HasMore();
}