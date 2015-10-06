using System;
using System.Collections.Generic;

namespace PhysicsCalculator
{
    public class Operand2DConverter
    {
        private readonly IDictionary<Measure, IDictionary<Measure, Func<Vector2D, Vector2D>>> _mapping =
            new Dictionary<Measure, IDictionary<Measure, Func<Vector2D, Vector2D>>>();

        public void AddMapping(Measure current, Measure target, Func<Vector2D, Vector2D> mapping)
        {
            if (!_mapping.ContainsKey(current))
            {
                _mapping.Add(new KeyValuePair<Measure, IDictionary<Measure, Func<Vector2D, Vector2D>>>());
            }
            _mapping[current].Add(target, mapping);
        }

        public bool TryConvert(Vector2DOperand operand, Measure current, Measure target, out Vector2DOperand result)
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
            result = new Vector2DOperand(_mapping[current][target].Invoke(operand.Value), target);
            return true;
        }
    }
}