using Itmo.ObjectOrientedProgramming.Lab4.ParseChain.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseChain.ArgumentsHandlers;

public record ArgumentHandlerContext<T>(ICommandIterator CommandIterator, T ContextBuilder);