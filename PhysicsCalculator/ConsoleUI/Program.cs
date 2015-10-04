using System.Collections.Generic;
using PhysicsCalculator;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var siMeasures = new SIMeasuresList();
            var d = new Dictionary<Measure,int>();
            d.Add(siMeasures.Kilogram,1);
             var pound = new Measure("фунт", 1/2.44, d);
             var op1=new Operand(2,pound);
             var op2 = new Operand(4,pound);
            var op3 = op1 * op2;
            
            /*  Measure meter = new Measure("meter", 1, new Dictionary<BasicMeasures, int> { { BasicMeasures.Metre, 1 } });
            Operand op1 = new Operand(2, new Dictionary<Measure, int> { { meter, 1 } });
            Operand op2 = new Operand(1, new Dictionary<Measure, int> { { meter, 1 } });
            var op3 = PhysicsMath.Pow(op1,3);*/
        }
    }
}
