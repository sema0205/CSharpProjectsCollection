using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public interface IBios : IValidator<IProcessor>
{
    public BiosType BiosType { get; }

    public IReadOnlyList<string> SupportedProcessors { get; }
}