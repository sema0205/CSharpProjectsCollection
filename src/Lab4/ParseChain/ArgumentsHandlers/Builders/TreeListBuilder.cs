using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public class TreeListBuilder
{
    private int _depth = 1;

    public TreeListBuilder WithDepth(int value)
    {
        _depth = value;
        return this;
    }

    public TreeListCommandContext Build()
    {
        return new TreeListCommandContext(_depth);
    }
}