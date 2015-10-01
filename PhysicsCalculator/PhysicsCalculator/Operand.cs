using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public class Operand
    {
        public double Value { get; protected set; }

        private IDictionary<Measure, int> _measurementUnits;

        public IDictionary<Measure, int> MeasurementUnits
        {
            get
            {
                return MeasureCalculator<Measure>.Clone(_measurementUnits);
            }
            protected set { _measurementUnits = value; }
        }

        public Operand(double value, IDictionary<Measure, int> measurementUnits)
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
            return new Operand(operand1.Value*operand2.Value, MeasureCalculator<Measure>.Multiply(operand1.MeasurementUnits, operand2.MeasurementUnits));
        }

        public static Operand operator /(double operand1, Operand operand2)
        {

            return new Operand(1.0/operand2.Value, MeasureCalculator<Measure>.Inverse(operand2.MeasurementUnits));
        }

        public static Operand operator /(Operand operand1, Operand operand2)
        {
            return operand1*(1/operand2);
        }

    }
}