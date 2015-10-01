using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public class Measure : IMeasure
    {
        public string Name { get; }

        private readonly Func<double, double> _mapping;

        private readonly Func<double, double> _inverseMapping;

        public IDictionary<SIMeasure, int> SIequivalent { get; }

        public Measure(string name, IDictionary<SIMeasure, int> sIequivalent, Func<double, double> mapping,
            Func<double, double> inverseMapping)
        {
            Name = name;
            _mapping = mapping;
            _inverseMapping = inverseMapping;
            SIequivalent = sIequivalent;
        }

        public Measure(string name, double multiplier, IDictionary<SIMeasure, int> sIequivalent)
        {
            Name = name;
            SIequivalent = sIequivalent;
            _mapping = x => x*multiplier;
            _inverseMapping = x => x/multiplier;
        }

        public double SIValue(double value)
        {
            return _mapping(value);
        }

        public double FromSI(double value)
        {
            return _inverseMapping(value);
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as Measure;
            return Equals(tmp);
        }

        protected bool Equals(Measure other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }

        public object Clone()
        {
            var cloneDictionary = SIequivalent.ToDictionary(item => item.Key, variable => variable.Value);
            var clone = new Measure(Name, cloneDictionary, _mapping, _inverseMapping);
            return clone;
        }

        public bool IsBaseSIMeasure => SIequivalent.Count == 1 && SIequivalent.First().Value == 1;
    }
}
