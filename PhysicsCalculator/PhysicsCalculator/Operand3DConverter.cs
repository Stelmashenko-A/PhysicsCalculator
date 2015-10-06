using System;
using System.Collections.Generic;

namespace PhysicsCalculator
{
    public class Operand3DConverter
    {
        private readonly IDictionary<Measure, IDictionary<Measure, Func<Vector3D, Vector3D>>> _mapping =
            new Dictionary<Measure, IDictionary<Measure, Func<Vector3D, Vector3D>>>();

        public void AddMapping(Measure current, Measure target, Func<Vector3D, Vector3D> mapping)
        {
            if (!_mapping.ContainsKey(current))
            {
                _mapping.Add(new KeyValuePair<Measure, IDictionary<Measure, Func<Vector3D, Vector3D>>>());
            }
            _mapping[current].Add(target, mapping);
        }

        public bool TryConvert(Vector3DOperand operand, Measure current, Measure target, out Vector3DOperand result)
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
            result = new Vector3DOperand(_mapping[current][target].Invoke(operand.Value), target);
            return true;
        }
    }
}