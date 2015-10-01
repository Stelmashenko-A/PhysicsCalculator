namespace PhysicsCalculator
{
    public class SIMeasure : IMeasure
    {
        internal SIMeasure(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public object Clone()
        {
            return new SIMeasure(Name);
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as SIMeasure;
            return Equals(tmp);
        }

        protected bool Equals(SIMeasure other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }
    }
}
