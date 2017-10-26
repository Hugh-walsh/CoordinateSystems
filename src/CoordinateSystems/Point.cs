using System;

namespace CoordinateSystems
{
    /// <summary>
    /// A point is a fixed location in space (reletive to a given transform)
    /// </summary>
    public class Point : IVector
    {
        /// <summary>
        /// Component in the X direction
        /// </summary>
        public double _x = 0.0;
        /// <summary>
        /// Component in the Y direction
        /// </summary>
        public double _y = 0.0;
        /// <summary>
        /// Component in the Z direction
        /// </summary>
        public double _z = 0.0;


        public Point()
        {
            this._x = 0.0;
            this._y = 0.0;
            this._z = 0.0;
        }
        public Point(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public static Vector operator -(Point a, Point b)
        {
            double vecX = a._x - b._x;
            double vecY = a._y - b._y;
            double vecZ = a._z - b._z;

            Vector newVector = new Vector(x: vecX, y: vecY, z: vecZ);

            return newVector;
        }

        public double X { get { return _x; } }

        public double Y { get { return _y; } }

        public double Z { get { return _z; } }
    }


}
