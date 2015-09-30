using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsCalculator
{
    public class Operand
    {
        public double Value { get; protected set; }

        public Dictionary<BasicMeasures, int> MeasurementUnits { get; protected set; }

        public Operand(double value, Dictionary<BasicMeasures, int> measurementUnits)
        {
            Value = value;
            MeasurementUnits = measurementUnits;
        }

        public static Operand operator +(Operand operand1, Operand operand2)
        {
            if (operand1.MeasurementUnits.Keys.Count != operand2.MeasurementUnits.Keys.Count) throw new Exception();
            if (operand1.MeasurementUnits.Keys.Any(variable => !operand2.MeasurementUnits.ContainsKey(variable)||operand2.MeasurementUnits[variable]!=operand1.MeasurementUnits[variable]))
            {
                throw new Exception();
            }
            return new Operand(operand1.Value + operand2.Value, operand1.MeasurementUnits);
        }

        public static Operand operator -(Operand operand1, Operand operand2)
        {
            return operand1 + (operand2*-1);
        }

        public static Operand operator *(Operand operand1, double operand2)
        {
            return new Operand(operand1.Value*operand2,operand1.MeasurementUnits);
        }

        public static Operand operator *(double operand1, Operand operand2)
        {
            return new Operand(operand2.Value*operand1, operand2.MeasurementUnits);
        }

        public static Operand operator *(Operand operand1, Operand operand2)
        {
            var measurementUnits = operand1.MeasurementUnits;
            foreach (var variable in operand2.MeasurementUnits.Keys)
            {
                if (measurementUnits.ContainsKey(variable))
                {
                    measurementUnits[variable] += operand2.MeasurementUnits[variable];
                }
                else
                {
                    measurementUnits.Add(variable,operand2.MeasurementUnits[variable]);
                }
            }
            foreach (var variable in measurementUnits.Keys.Where(variable => measurementUnits[variable] == 0))
            {
                measurementUnits.Remove(variable);
            }
            return new Operand(operand1.Value*operand2.Value, measurementUnits);
        }
    }
}
