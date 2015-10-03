using System;

namespace PhysicsCalculator
{
    public static class PhysicsMath
    {
        public static Operand Pow(Operand operand, int power)
        {
            return new Operand(Math.Pow(operand.MeasurementUnits.SIValue(operand.Value), power),
                 new Measure("unnamed", MeasureCalculator<Measure>.Pow(operand.MeasurementUnits.SIequivalent, power),
                     x => x, x => x));
        }

        public static Operand Sqrt(Operand operand)
        {
            return new Operand(Math.Sqrt(operand.MeasurementUnits.SIValue(operand.Value)),
                new Measure("unnamed", MeasureCalculator<Measure>.Root(operand.MeasurementUnits.SIequivalent, 2),
                    x => x, x => x));
        }

        public static Operand Root(Operand operand, int power)
        {
            return new Operand(Math.Pow(operand.MeasurementUnits.SIValue(operand.Value), 1 / (double)power),
                new Measure("unnamed", MeasureCalculator<Measure>.Root(operand.MeasurementUnits.SIequivalent, power),
                    x => x, x => x));
        }
    }
}