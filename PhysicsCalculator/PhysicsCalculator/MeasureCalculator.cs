using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public static class MeasureCalculator
    {
        public static IDictionary<Measure, int> Clone(IDictionary<Measure, int> obj)
        {
            var clone = new Dictionary<Measure, int>();
            foreach (var variable in obj)
            {
                var objClone = variable.Key.Clone();
                var tmp = objClone as Measure;
                if (tmp != null)
                {
                    clone.Add(tmp, variable.Value);
                }
            }
            return clone;
        }

        public static bool CheckForEquals(IDictionary<Measure, int> summand1, IDictionary<Measure, int> summand2)
        {
            if (summand1.Count != summand2.Keys.Count) return false;
            return !summand1.Keys.Any(
                variable =>
                    !summand2.ContainsKey(variable) ||
                    summand2[variable] != summand1[variable]);
        }

        public static bool CheckForEquals(Measure measure1, Measure measure2)
        {
            if (measure1.Name!="unnamed" && measure2.Name!="unnamed"&&measure1.Name != measure2.Name)
            {
                return false;
            }
            if (measure1.IsBasicIsMeasure && measure2.IsBasicIsMeasure)
            {
                return true;
            }
            var measure1Si = measure1.Equivalent;
            var measure2Si = measure2.Equivalent;
            if (measure2Si.Count != measure1Si.Count)
                return false;
            foreach (var VARIABLE in measure1Si.Keys)
            {
                if (!measure2Si.ContainsKey(VARIABLE))
                    return false;
                if (measure2Si[VARIABLE] != measure1Si[VARIABLE])
                    return false;
            }
            return true;
        }

        public static bool CheckForEqualsSi(Measure measure1, Measure measure2)
        {
            if (measure1.IsBasicIsMeasure && measure2.IsBasicIsMeasure)
            {
                return true;
            }
            var measure1Si = measure1.SIequivalent;
            var measure2Si = measure2.SIequivalent;
            if (measure2Si.Count != measure1Si.Count)
                return false;
            foreach (var VARIABLE in measure1Si.Keys)
            {
                if (!measure2Si.ContainsKey(VARIABLE))
                    return false;
                if (measure2Si[VARIABLE] != measure1Si[VARIABLE])
                    return false;
            }
            return true;
        }

        public static IDictionary<Measure, int> Inverse(IDictionary<Measure, int> measure)
        {
            return measure.ToDictionary(variable => variable.Key, variable => variable.Value*-1);
        }

        public static Measure Inverse(Measure measure)
        {
            return new Measure("unnamed", Inverse(measure.Equivalent), Inverse(measure.SIequivalent));
        }

        public static IDictionary<Measure, int> Multiply(IDictionary<Measure, int> multiplier1,
            IDictionary<Measure, int> multiplier2)
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

        public static Measure Multiply(Measure measure1, Measure measure2)
        {
            return new Measure("unnamed", Multiply(measure1.Equivalent, measure2.Equivalent),
                Multiply(measure1.SIequivalent, measure2.SIequivalent));
        }

        public static IDictionary<Measure, int> Divide(IDictionary<Measure, int> divident,
            IDictionary<Measure, int> divider)
        {
            return Multiply(divident, Inverse(divider));
        }

        public static Measure Divide(Measure measure1, Measure measure2)
        {
            return Multiply(measure1, Inverse(measure2));
        }

        public static IDictionary<Measure, int> Pow(IDictionary<Measure, int> value, int power)
        {
            if (power == 0)
            {
                return new Dictionary<Measure, int>();
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


        public static Measure Pow(Measure measure, int pow)
        {
            return new Measure("unnamed", Pow(measure.Equivalent, pow), Pow(measure.SIequivalent, pow));
        }

        public static IDictionary<Measure, int> Root(IDictionary<Measure, int> value, int power)
        {
            if (power == 0)
            {
                return Pow(value, 0);
            }

            var tmp = value;
            foreach (var variable in tmp.Keys.ToList())
            {
                if (tmp[variable]%Math.Abs(power) != 0)
                {
                    throw new RootException();
                }
                tmp[variable] /= Math.Abs(power);
            }
            return tmp;
        }

        public static Measure Root(Measure measure, int pow)
        {
            return new Measure("unnamed", Root(measure.Equivalent, pow), Root(measure.SIequivalent, pow));
        }
    }
}