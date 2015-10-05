namespace PhysicsCalculator
{
    public class Vector2DOperand
    {
        public Vector2D Value { get; }

        private Measure _measure;

        public Measure MeasurementUnits
        {
            get { return _measure.Clone() as Measure; }
            protected set { _measure = value; }
        }

        public Vector2DOperand(Vector2D vector, Measure measure)
        {
            Value = vector;
            _measure = measure;
        }

        public static Vector2DOperand operator +(Vector2DOperand operand1, Vector2DOperand operand2)
        {
            if (!MeasureCalculator.CheckForEquals(operand1.MeasurementUnits, operand2.MeasurementUnits))
                throw new SumException();
            return new Vector2DOperand(operand1.Value + operand2.Value, operand1.MeasurementUnits);
        }

        public static Vector2DOperand operator -(Vector2DOperand operand1, Vector2DOperand operand2)
        {
            if (!MeasureCalculator.CheckForEquals(operand1.MeasurementUnits, operand2.MeasurementUnits))
                throw new SubtractionException();
            return new Vector2DOperand(operand1.Value - operand2.Value, operand1.MeasurementUnits);
        }

        public static Vector2DOperand operator *(Vector2DOperand operand1, double operand2)
        {
            return new Vector2DOperand(operand1.Value*operand2, operand1.MeasurementUnits);
        }


        public static Vector2DOperand operator *(Vector2DOperand operand1, Operand operand2)
        {
            return new Vector2DOperand(operand1.Value*operand2.Value,
                MeasureCalculator.Multiply(operand1.MeasurementUnits,
                    operand2.MeasurementUnits));
        }

        public static Vector2DOperand operator *(Operand operand1, Vector2DOperand operand2)
        {
            return operand2*operand1;
        }

        public static Vector2DOperand operator *(double operand1, Vector2DOperand operand2)
        {
            return new Vector2DOperand(operand2.Value*operand1, operand2.MeasurementUnits);
        }

        public static Operand operator *(Vector2DOperand operand1, Vector2DOperand operand2)
        {
            return new Operand(operand1.Value*operand2.Value,
                MeasureCalculator.Multiply(operand1.MeasurementUnits, operand2.MeasurementUnits));
        }

        public static Vector2DOperand operator /(Vector2DOperand operand1, double operand2)
        {
            return operand1*(1/operand2);
        }
    }
}
