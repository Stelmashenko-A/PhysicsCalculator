using System;

namespace PhysicsCalculator
{
    public static class PhysicsMath
    {
        public static Operand Pow(Operand operand, int power)
        {
            return new Operand(Math.Pow(operand.Value, power),
                MeasureCalculator.Pow(operand.MeasurementUnits, power));
        }

        public static Operand Sqrt(Operand operand)
        {
            return new Operand(Math.Sqrt(operand.Value),
                MeasureCalculator.Root(operand.MeasurementUnits, 2));
        }

        public static Operand Root(Operand operand, int power)
        {
            return new Operand(Math.Pow(operand.Value, 1/(double) power),
                MeasureCalculator.Root(operand.MeasurementUnits, power));
        }
    }
}