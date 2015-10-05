namespace PhysicsCalculator
{
    public class VectorOperand
    {
        public Vector2D Value { get; }

        private Measure _measure;

        public Measure MeasurementUnits
        {
            get { return _measure.Clone() as Measure; }
            protected set { _measure = value; }
        }

        public VectorOperand(Vector2D vector, Measure measure)
        {
            Value = vector;
            _measure = measure;
        }

        public static VectorOperand operator +(VectorOperand operand1, VectorOperand operand2)
        {
            if (!MeasureCalculator.CheckForEquals(operand1.MeasurementUnits, operand2.MeasurementUnits))
                throw new SumException();
            return new VectorOperand(operand1.Value + operand2.Value, operand1.MeasurementUnits);
        }

        public static VectorOperand operator -(VectorOperand operand1, VectorOperand operand2)
        {
            if (!MeasureCalculator.CheckForEquals(operand1.MeasurementUnits, operand2.MeasurementUnits))
                throw new SubtractionException();
            return new VectorOperand(operand1.Value - operand2.Value, operand1.MeasurementUnits);
        }

        public static VectorOperand operator *(VectorOperand operand1, double operand2)
        {
            return new VectorOperand(operand1.Value*operand2, operand1.MeasurementUnits);
        }


        public static VectorOperand operator *(VectorOperand operand1, Operand operand2)
        {
            return new VectorOperand(operand1.Value*operand2.Value,
                MeasureCalculator.Multiply(operand1.MeasurementUnits,
                    operand2.MeasurementUnits));
        }

        public static VectorOperand operator *(Operand operand1, VectorOperand operand2)
        {
            return operand2*operand1;
        }

        public static VectorOperand operator *(double operand1, VectorOperand operand2)
        {
            return new VectorOperand(operand2.Value*operand1, operand2.MeasurementUnits);
        }

        public static Operand operator *(VectorOperand operand1, VectorOperand operand2)
        {
            return new Operand(operand1.Value*operand2.Value,MeasureCalculator.Multiply(operand1.MeasurementUnits,operand2.MeasurementUnits));
        }

        public static VectorOperand operator /(VectorOperand operand1, double operand2)
        {
            return operand1*(1/operand2);
        }
    }
}
