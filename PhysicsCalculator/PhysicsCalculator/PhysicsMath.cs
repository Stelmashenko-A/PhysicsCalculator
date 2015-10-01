using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public static class PhysicsMath
    {
        public static Operand Pow(Operand operand, int power)
        {
            if (power == 0)
            {
                return new Operand(1, new Dictionary<Measure, int>());
            }

           

            var result = new Operand(operand.Value, operand.MeasurementUnits);
            for (var i = 1; i < Math.Abs(power); i++)
            {
                result *= operand;
            }

            if (power < 0)
            {
                result = 1/result;
            }
            return result;
        }

        public static Operand Sqrt(Operand operand)
        {
            var tmp = operand.MeasurementUnits;
            foreach (var variable in tmp.Keys)
            {
                if (tmp[variable]%2 != 0)
                {
                    throw new Exception();
                }
                tmp[variable] /= 2;
            }
            return new Operand(Math.Sqrt(operand.Value), tmp);
        }

        public static Operand Root(Operand operand, int power)
        {


            var result = new Operand(Math.Pow(operand.Value, 1/(double)power), MeasureCalculator<Measure>.Root(operand.MeasurementUnits,power));

            return result;
        }
    }
}