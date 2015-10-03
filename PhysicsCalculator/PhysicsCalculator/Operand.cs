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
            if(!MeasureCalculator<Measure>.CheckForEquals(operand1.MeasurementUnits,operand2.MeasurementUnits)) throw new SumException();
            return new Operand(operand1.Value + operand2.Value, operand1.MeasurementUnits);
        }

        public static Operand operator -(Operand operand1, Operand operand2)
        {
            try
            {
                return operand1 + (operand2*-1);
            }
            catch (SumException)
            {
                throw new SubtractionException();
            }
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
            return new Operand(operand1._measure.SIValue(operand1.Value)* operand2._measure.SIValue(operand2.Value),
                new Measure("unnamed",
                    MeasureCalculator<Measure>.Multiply(operand1.MeasurementUnits.SIequivalent,
                        operand2.MeasurementUnits.SIequivalent), x => x, x => x));
        }

        public static Operand operator /(double operand1, Operand operand2)
        {

            return new Operand(1.0/operand2._measure.SIValue(operand2.Value), new Measure("unnamed", MeasureCalculator<Measure>.Inverse(operand2.MeasurementUnits.SIequivalent), x => x, x => x));
        }

        public static Operand operator /(Operand operand1, Operand operand2)
        {
            return operand1*(1/operand2);
        }
    }
}