using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public class Measure : IMeasure
    {
        public string Name { get; }

        public bool IsBasicIsMeasure { get; }

        private readonly Func<double, double> _mapping;

        private readonly Func<double, double> _inverseMapping;

        public IDictionary<Measure, int> SIequivalent { get; }

        internal Measure(string name)
        {
            Name = name;
            IsBasicIsMeasure = true;
            SIequivalent = new Dictionary<Measure, int>();
            SIequivalent.Add(this, 1);
        }

        public Measure()
        {
            Name = "unmeasured";
            IsBasicIsMeasure = true;
            SIequivalent = new Dictionary<Measure, int>();
        }

        public Measure(string name, IDictionary<Measure, int> sIequivalent, Func<double, double> mapping,
            Func<double, double> inverseMapping)
        {
            Name = name;
            _mapping = mapping;
            _inverseMapping = inverseMapping;
            SIequivalent = sIequivalent;
            IsBasicIsMeasure = false;
        }

        public Measure(string name, double multiplier, IDictionary<Measure, int> sIequivalent)
        {
            Name = name;
            SIequivalent = sIequivalent;
            _mapping = x => x*multiplier;
            _inverseMapping = x => x/multiplier;
        }

        public double SIValue(double value)
        {
            return IsBasicIsMeasure ? value : _mapping(value);
        }

        public double FromSI(double value)
        {
            return IsBasicIsMeasure ? value : _inverseMapping(value);
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
            return new Measure(Name, cloneDictionary, _mapping, _inverseMapping);
        }
    }
}