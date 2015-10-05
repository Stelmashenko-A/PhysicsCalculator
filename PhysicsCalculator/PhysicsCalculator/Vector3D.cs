using System;

namespace PhysicsCalculator
{
    public class Vector3D
    {
        public Vector3D(double length, double cornerX, double cornerY, double cornerZ)
        {
            Length = length;
            CornerX = cornerX;
            CornerY = cornerY;
            CornerZ = cornerZ;
            Coordinate3D = new Coordinate3D(Math.Cos(CornerX)*Length, Math.Cos(CornerY) * Length, Math.Cos(CornerZ) * Length);
        }

        public Vector3D(Coordinate3D coordinate3D)
        {
            Coordinate3D = coordinate3D;
            Length = Math.Sqrt(Math.Pow(Coordinate3D.X, 2) + Math.Pow(Coordinate3D.Y, 2) + Math.Pow(Coordinate3D.Z, 2));

            CornerX = Math.Acos(Coordinate3D.X/Length);
            CornerY = Math.Acos(Coordinate3D.Y/Length);
            CornerZ = Math.Acos(Coordinate3D.Z/Length);
        }

        public readonly Coordinate3D Coordinate3D;

        public double Length { get; }

        public double CornerX { get; }
        public double CornerY { get; }
        public double CornerZ { get; }
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return
                new Vector3D(new Coordinate3D(vector1.Coordinate3D.X + vector2.Coordinate3D.X,
                    vector1.Coordinate3D.Y, vector2.Coordinate3D.Y+vector1.Coordinate3D.Z+vector2.Coordinate3D.Z));
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return
                new Vector3D(new Coordinate3D(vector1.Coordinate3D.X - vector2.Coordinate3D.X,
                    vector1.Coordinate3D.Y, vector2.Coordinate3D.Y - vector1.Coordinate3D.Z - vector2.Coordinate3D.Z));
        }

        public static double operator *(Vector3D vector1, Vector3D vector2)
        {
            return vector1.Coordinate3D.X * vector2.Coordinate3D.X + vector1.Coordinate3D.Y * vector2.Coordinate3D.Y + vector1.Coordinate3D.Z * vector2.Coordinate3D.Z;
        }

        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(new Coordinate3D(vector.Coordinate3D.X * scalar, vector.Coordinate3D.Y * scalar, vector.Coordinate3D.Z * scalar));
        }

        public static Vector3D operator *(double scalar, Vector3D vector)
        {
            return vector * scalar;
        }
    }
}