using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain;

public record CommandHandlerContext(ICommandIterator CommandIterator);