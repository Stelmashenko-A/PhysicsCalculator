using System;

namespace PhysicsCalculator
{
    internal class Vector2D
    {
        public Vector2D(double length, double corner)
        {
            Length = length;
            Corner = corner;
            Coordinate2D = new Coordinate2D(Math.Cos(corner)*length, Math.Sin(corner)*length);
        }

        public Vector2D(Coordinate2D coordinate2D)
        {
            Coordinate2D = coordinate2D;

            Length = Math.Sqrt(Math.Pow(Coordinate2D.X, 2) + Math.Pow(Coordinate2D.Y, 2));
            Corner = Math.Asin(Coordinate2D.Y/Length);

        }

        public readonly Coordinate2D Coordinate2D;

        public double Length { get; }

        public double Corner { get; }

        public static Vector2D operator +(Vector2D vector1, Vector2D vector2)
        {
            return
                new Vector2D(new Coordinate2D(vector1.Coordinate2D.X + vector2.Coordinate2D.X,
                    vector1.Coordinate2D.Y + vector2.Coordinate2D.Y));
        }

        public static Vector2D operator -(Vector2D vector1, Vector2D vector2)
        {
            return
                new Vector2D(new Coordinate2D(vector1.Coordinate2D.X - vector2.Coordinate2D.X,
                    vector1.Coordinate2D.Y - vector2.Coordinate2D.Y));
        }

        public static double operator *(Vector2D vector1, Vector2D vector2)
        {
            return vector1.Coordinate2D.X*vector2.Coordinate2D.X + vector1.Coordinate2D.Y + vector2.Coordinate2D.Y;
        }

        public static Vector2D operator * (Vector2D vector, double scalar)
        {
            return new Vector2D(new Coordinate2D(vector.Coordinate2D.X*scalar, vector.Coordinate2D.Y*scalar));
        }

        public static Vector2D operator *(double scalar, Vector2D vector)
        {
            return vector*scalar;
        }

    }

    public class Coordinate2D
    {
        public Coordinate2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }
}
