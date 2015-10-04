using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public class Measure
    {
        public string Name { get; }

        public bool IsBasicIsMeasure { get; }

        public IDictionary<Measure, int> SIequivalent { get; }

        public IDictionary<Measure, int> Equivalent { get; }

        internal Measure(string name)
        {
            Name = name;
            IsBasicIsMeasure = true;
            SIequivalent = new Dictionary<Measure, int>();
            SIequivalent.Add(this, 1);
            Equivalent = SIequivalent;
        }

        public Measure()
        {
            Name = "unmeasured";
            IsBasicIsMeasure = true;
            SIequivalent = new Dictionary<Measure, int>();
        }

        public Measure(string name, IDictionary<Measure, int> equivalent, IDictionary<Measure, int> sIequivalent)
        {
            Name = name;
            SIequivalent = sIequivalent;
            IsBasicIsMeasure = false;
            Equivalent = equivalent;
        }

        public Measure(string name, IDictionary<Measure, int> sIequivalent)
        {
            Name = name;
            SIequivalent = sIequivalent;
            IsBasicIsMeasure = false;
            Equivalent = new Dictionary<Measure, int>();
            Equivalent.Add(this, 1);
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
            var cloneDictionary1 = SIequivalent.ToDictionary(item => item.Key, variable => variable.Value);
            var cloneDictionary2 = Equivalent.ToDictionary(item => item.Key, variable => variable.Value);
            return new Measure(Name, cloneDictionary2, cloneDictionary1);
        }
    }
}