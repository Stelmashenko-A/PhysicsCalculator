using System;
using System.Collections.Generic;

namespace PhysicsCalculator
{
    public interface IMeasure:ICloneable
    {
        IDictionary<Measure, int> SIequivalent { get; }
    }
}
