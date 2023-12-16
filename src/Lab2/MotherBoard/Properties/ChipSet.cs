using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

public record ChipSet(IEnumerable<double> MemoryFrequencies, bool XmpSupport);