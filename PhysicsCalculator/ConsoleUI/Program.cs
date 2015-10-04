using System.Collections.Generic;
using PhysicsCalculator;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            DerivedMeasure derivedMeasure = new DerivedMeasure();
            var siMeasures = new SIMeasuresList();
            var d = new Dictionary<Measure, int>();
            d.Add(siMeasures.Kilogram, 1);
            var pound = new Measure("фунт", d);
            var op1 = new Operand(2, derivedMeasure.Newton);
            var op2 = new Operand(4, siMeasures.Kilogram);
            var op3 = op1/op2;

            /*  Measure meter = new Measure("meter", 1, new Dictionary<BasicMeasures, int> { { BasicMeasures.Metre, 1 } });
            Operand op1 = new Operand(2, new Dictionary<Measure, int> { { meter, 1 } });
            Operand op2 = new Operand(1, new Dictionary<Measure, int> { { meter, 1 } });
            var op3 = PhysicsMath.Pow(op1,3);*/
        }
    }
}