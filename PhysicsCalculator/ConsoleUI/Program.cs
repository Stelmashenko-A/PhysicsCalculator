using System;
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
            var d = new Dictionary<Measure, int> {{siMeasures.Kilogram, 1}};
            var pound = new Measure("фунт", d);
            var op1 = new Operand(2, derivedMeasure.Becquerel);
            var op2 = new Operand(4, derivedMeasure.Volt);
            var force = new Vector2DOperand(new Vector2D(Math.Sqrt(2.0)*2, Math.PI/4), derivedMeasure.Newton);
            var path = new Vector2DOperand(new Vector2D(2, 0), siMeasures.Metre);
            Operand op3 = force*path;
            /*  Measure meter = new Measure("meter", 1, new Dictionary<BasicMeasures, int> { { BasicMeasures.Metre, 1 } });
            Operand op1 = new Operand(2, new Dictionary<Measure, int> { { meter, 1 } });
            Operand op2 = new Operand(1, new Dictionary<Measure, int> { { meter, 1 } });
            var op3 = PhysicsMath.Pow(op1,3);*/
        }
    }
}