using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinateSystems
{
    public abstract class AbstractVector
    {
        protected double _x;
        protected double _y;
        protected double _z;

        protected AbstractVector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double DotProduct(AbstractVector vector)
        {
            double a1b1 = this._x * vector.X;
            double a2b2 = this._y * vector.Y;
            double a3b3 = this._z * vector.Z;
            double dotProduct = a1b1 + a2b2 + a3b3;
            return dotProduct;
        }

        /// <summary>
        /// Overloaded + operator for vector addition. Note that adding unit vectors produces a vector.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator +(AbstractVector a, AbstractVector b)
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
        public static Vector operator *(double a, AbstractVector b)
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
