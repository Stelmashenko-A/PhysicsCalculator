using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsCalculator
{
    public class SIMeasuresList
    {
        public SIMeasure Metre => new SIMeasure("Metre");
        public SIMeasure Kilogram => new SIMeasure("Kilogram");
        public SIMeasure Second => new SIMeasure("Second");
        public SIMeasure Ampere => new SIMeasure("Ampere");
        public SIMeasure Kelvin => new SIMeasure("Kelvin");
        public SIMeasure Mole => new SIMeasure("Mole");
        public SIMeasure Candela => new SIMeasure("Candela");
    }
}
