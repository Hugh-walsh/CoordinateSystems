using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinateSystems
{
    /// <summary>
    /// A vector can be any magnitude and it represents a transpose between 2 points.  
    /// </summary>
    public class Vector : IVector
    {

        readonly double _x;
        readonly double _y;
        readonly double _z;

        public Vector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public static implicit operator Vector(UnitVector unitVector)
        {
            return new Vector(x: unitVector.X, y: unitVector.Y, z: unitVector.Z);
        }

        /// <summary>
        /// TODO: Move this to an external helper function class
        /// </summary>
        /// <param name="vectorA"></param>
        /// <param name="vectorB"></param>
        /// <returns></returns>
        public static double DotProduct(IVector vectorA, IVector vectorB)
        {
            double a1b1 = vectorA.X * vectorB.X;
            double a2b2 = vectorA.Y * vectorB.Y;
            double a3b3 = vectorA.Z * vectorB.Z;
            double dotProduct = a1b1 + a2b2 + a3b3;
            return dotProduct;
        }

        /// <summary>
        /// Overloaded + operator for vector addition. Note that adding unit vectors produces a vector.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {
            double newX = a.X + b.X;
            double newY = a.Y + a.Y;
            double newZ = a.Z + a.Z;

            Vector newVector = new Vector(x: newX, y: newY, z: newZ);

            return newVector;
        }

        /// <summary>
        /// Overloaded * operator for scalar addition. Note that multiplying unit vectors produces a vector.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(double a, Vector b)
        {
            double newX = a * b.X;
            double newY = a * b.Y;
            double newZ = a * b.Z;

            Vector newVector = new Vector(x: newX, y: newY, z: newZ);

            return newVector;
        }

        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public double Z
        {
            get { return _z; }
        }

    }


}
