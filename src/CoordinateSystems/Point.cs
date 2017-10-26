using System;

namespace CoordinateSystems
{
    /// <summary>
    /// A point is a fixed location in space (reletive to a given transform)
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Component in the X direction
        /// </summary>
        public double X = 0.0;
        /// <summary>
        /// Component in the Y direction
        /// </summary>
        public double Y = 0.0;
        /// <summary>
        /// Component in the Z direction
        /// </summary>
        public double Z = 0.0;

        public static Vector operator -(Point a, Point b)
        {
            double vecX = a.X - b.X;
            double vecY = a.Y - b.Y;
            double vecZ = a.Z - b.Z;

            Vector newVector = new Vector(x: vecX, y: vecY, z: vecZ);

            return newVector;
        }
    }


}
