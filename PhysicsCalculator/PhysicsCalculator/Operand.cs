using System;
using System.Collections.Generic;

namespace PhysicsCalculator
{
    public class Operand
    {
        public double Value { get; protected set; }

        private Measure _measure;

        public Measure MeasurementUnits
        {
            get
            {
                return _measure.Clone() as Measure;
            }
            protected set { _measure = value; }
        }

        public Operand(double value, Measure measurementUnits)
        {
            Value = value;
            MeasurementUnits = measurementUnits;
        }


        public static Operand operator +(Operand operand1, Operand operand2)
        {
            if(!MeasureCalculator<Measure>.CheckForEquals(operand1.MeasurementUnits,operand2.MeasurementUnits)) throw new Exception();
            return new Operand(operand1.Value + operand2.Value, operand1.MeasurementUnits);
        }

        public static Operand operator -(Operand operand1, Operand operand2)
        {
            return operand1 + (operand2*-1);
        }

        public static Operand operator *(Operand operand1, double operand2)
        {
            return new Operand(operand1.Value*operand2, operand1.MeasurementUnits);
        }

        public static Operand operator *(double operand1, Operand operand2)
        {
            return new Operand(operand2.Value*operand1, operand2.MeasurementUnits);
        }

        public static Operand operator *(Operand operand1, Operand operand2)
        {
            return new Operand(operand1.Value*operand2.Value,
                new Measure("unnamed",
                    MeasureCalculator<Measure>.Multiply(operand1.MeasurementUnits.SIequivalent,
                        operand2.MeasurementUnits.SIequivalent), x => x, x => x));
        }

        public static Operand operator /(double operand1, Operand operand2)
        {

            return new Operand(1.0/operand2.Value, new Measure("unnamed", MeasureCalculator<Measure>.Inverse(operand2.MeasurementUnits.SIequivalent), x => x, x => x));
        }

        public static Operand operator /(Operand operand1, Operand operand2)
        {
            return operand1*(1/operand2);
        }
    }
}