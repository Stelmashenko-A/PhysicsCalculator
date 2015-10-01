using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public static class MeasureCalculator<T> where T:class , IMeasure
    {
        public static IDictionary<T, int> Clone(IDictionary<T, int> obj)
        {
            var clone = new Dictionary<T,int>();
            foreach (var variable in obj)
            {
                var objClone = variable.Key.Clone();
                var tmp = objClone as T;
                if (tmp != null)
                {
                    clone.Add(tmp, variable.Value);
                }
            }
            return clone;
        }

        public static bool CheckForEquals(IDictionary<T, int> summand1, IDictionary<T, int> summand2)
        {
            if (summand1.Count != summand2.Keys.Count) return false;
            return !summand1.Keys.Any(
                variable =>
                    !summand2.ContainsKey(variable) ||
                    summand2[variable] != summand1[variable]);
        }

        public static IDictionary<T, int> Inverse(IDictionary<T, int> measure)
        {
            return measure.ToDictionary(variable => variable.Key, variable => variable.Value*-1);
        }

        public static IDictionary<T, int> Multiply(IDictionary<T, int> multiplier1, IDictionary<T, int> multiplier2)
        {
            var measurementUnits = Clone(multiplier1);
            var multiplier2Clone = Clone(multiplier2);
            foreach (var variable in multiplier2Clone.Keys.ToList())
            {
                if (measurementUnits.ContainsKey(variable))
                {
                    measurementUnits[variable] += multiplier2Clone[variable];
                }
                else
                {
                    measurementUnits.Add(variable, multiplier2Clone[variable]);
                }
            }
            return measurementUnits;
        }

        public static IDictionary<T, int> Divide(IDictionary<T, int> divident, IDictionary<T, int> divider)
        {
            return Multiply(divident, Inverse(divider));
        }

        public static IDictionary<T, int> Pow(IDictionary<T, int> value, int power)
        {
            if (power == 0)
            {
                return new Dictionary<T, int>();
            }

            var result = Clone(value);
            for (var i = 1; i < Math.Abs(power); i++)
            {
                result = Multiply(result, value);
            }

            if (power < 0)
            {
                result = Inverse(result);
            }
            return result;
        }

        public static IDictionary<T, int> Root(IDictionary<T, int> value, int power)
        {
            if (power == 0)
            {
                return Pow(value, 0);
            }
            var tmp = value;
            foreach (var variable in tmp.Keys.ToList())
            {
                if (tmp[variable] % Math.Abs(power) != 0)
                {
                    throw new Exception();
                }
                tmp[variable] /= Math.Abs(power);
            }

            return tmp;
        }

    }
}