using System;
using System.Collections.Generic;

namespace PhysicsCalculator
{
    public class OperandConverter
    {
        private readonly IDictionary<Measure, IDictionary<Measure, Func<double, double>>> _mapping =
            new Dictionary<Measure, IDictionary<Measure, Func<double, double>>>();

        public void AddMapping(Measure current, Measure target, Func<double, double> mapping)
        {
            if (!_mapping.ContainsKey(current))
            {
                _mapping.Add(new KeyValuePair<Measure, IDictionary<Measure, Func<double, double>>>());
            }
            _mapping[current].Add(target, mapping);
        }

        public bool TryConvert(Operand operand, Measure current, Measure target, out Operand result)
        {
            if (!_mapping.ContainsKey(current))
            {
                result = null;
                return false;
            }

            if (!_mapping[current].ContainsKey(target))
            {
                result = null;
                return false;
            }
            result = new Operand(_mapping[current][target].Invoke(operand.Value), target);
            return true;
        }
    }
}