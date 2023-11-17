using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.ArgumentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers.Builders;

public class TreeListBuilder
{
    private int _depth = 1;

    public TreeListBuilder WithDepth(int value)
    {
        _depth = value;
        return this;
    }

    public ArgumentContext.TreeListCommandContext Build()
    {
        return new ArgumentContext.TreeListCommandContext(_depth);
    }
}