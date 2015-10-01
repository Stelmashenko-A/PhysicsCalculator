using System.Collections.Generic;
using PhysicsCalculator;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            SIMeasuresList siMeasures = new SIMeasuresList();
             Measure meter= new Measure("meter",1, new Dictionary<SIMeasure, int> { { siMeasures.Metre, 1 } });
             Operand op1=new Operand(2,new Dictionary<Measure, int> { {meter,1} });
             Operand op2 = new Operand(1, new Dictionary<Measure, int> { { meter, 1 } });
             var op3 = op2 / op1;
          /*  Measure meter = new Measure("meter", 1, new Dictionary<BasicMeasures, int> { { BasicMeasures.Metre, 1 } });
            Operand op1 = new Operand(2, new Dictionary<Measure, int> { { meter, 1 } });
            Operand op2 = new Operand(1, new Dictionary<Measure, int> { { meter, 1 } });
            var op3 = PhysicsMath.Pow(op1,3);*/
        }
    }
}
