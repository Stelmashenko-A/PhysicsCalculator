namespace PhysicsCalculator
{
    public class Vector3DOperand
    {
        public Vector3D Value { get; }

        private Measure _measure;

        public Measure MeasurementUnits
        {
            get { return _measure.Clone() as Measure; }
            protected set { _measure = value; }
        }

        public Vector3DOperand(Vector3D vector, Measure measure)
        {
            Value = vector;
            _measure = measure;
        }

        public static Vector3DOperand operator +(Vector3DOperand operand1, Vector3DOperand operand2)
        {
            if (!MeasureCalculator.CheckForEquals(operand1.MeasurementUnits, operand2.MeasurementUnits))
                throw new SumException();
            return new Vector3DOperand(operand1.Value + operand2.Value, operand1.MeasurementUnits);
        }

        public static Vector3DOperand operator -(Vector3DOperand operand1, Vector3DOperand operand2)
        {
            if (!MeasureCalculator.CheckForEquals(operand1.MeasurementUnits, operand2.MeasurementUnits))
                throw new SubtractionException();
            return new Vector3DOperand(operand1.Value - operand2.Value, operand1.MeasurementUnits);
        }

        public static Vector3DOperand operator *(Vector3DOperand operand1, double operand2)
        {
            return new Vector3DOperand(operand1.Value*operand2, operand1.MeasurementUnits);
        }

        public static Vector3DOperand operator *(Vector3DOperand operand1, Operand operand2)
        {
            return new Vector3DOperand(operand1.Value*operand2.Value,
                MeasureCalculator.Multiply(operand1.MeasurementUnits,
                    operand2.MeasurementUnits));
        }

        public static Vector3DOperand operator *(Operand operand1, Vector3DOperand operand2)
        {
            return operand2*operand1;
        }

        public static Vector3DOperand operator *(double operand1, Vector3DOperand operand2)
        {
            return new Vector3DOperand(operand2.Value*operand1, operand2.MeasurementUnits);
        }

        public static Operand operator *(Vector3DOperand operand1, Vector3DOperand operand2)
        {
            return new Operand(operand1.Value*operand2.Value,
                MeasureCalculator.Multiply(operand1.MeasurementUnits, operand2.MeasurementUnits));
        }

        public static Vector3DOperand operator /(Vector3DOperand operand1, double operand2)
        {
            return operand1*(1/operand2);
        }
    }
}