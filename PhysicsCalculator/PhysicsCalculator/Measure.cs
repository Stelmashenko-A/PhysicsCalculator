using System;
using System.Collections.Generic;

namespace PhysicsCalculator
{
    public class Measure
    {
        public string Name { get; }

        private readonly Func<double, double> _mapping;

        private readonly Func<double, double> _inverseMapping;

        public IDictionary<BasicMeasures, int> SIequivalent { get; }

        public Measure(string name, IDictionary<BasicMeasures, int> sIequivalent, Func<double, double> mapping, Func<double, double> inverseMapping)
        {
            Name = name;
            _mapping = mapping;
            _inverseMapping = inverseMapping;
            SIequivalent = sIequivalent;
        }

        public Measure(string name, double multiplier, IDictionary<BasicMeasures, int> sIequivalent)
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
            return Equals(this, tmp);
        }

        protected bool Equals(Measure other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }
    }
}
