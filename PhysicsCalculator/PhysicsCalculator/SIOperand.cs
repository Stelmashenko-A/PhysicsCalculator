using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    class SIOperand
    {
        private Dictionary<SIMeasure, int> _measurementUnits;

        public Dictionary<SIMeasure, int> MeasurementUnits
        {
            get
            {
                return (from variable in _measurementUnits let clone = variable.Key select variable).ToDictionary(variable => variable.Key, variable => variable.Value);
            }
            protected set { _measurementUnits = value; }
        }
    }
}
