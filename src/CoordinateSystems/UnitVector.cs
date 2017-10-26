using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinateSystems
{
    /// <summary>
    /// The Unit vector is a vector where the magnitude is always 1
    /// </summary>
    public sealed class UnitVector : IVector
    {
        readonly double _x;
        readonly double _y;
        readonly double _z;

        public UnitVector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Returns a vector with unitary magnitude
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static UnitVector FromArbitraryOrdinates(double x, double y, double z)
        {
            double vectorNorm = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            double normX = x / vectorNorm;
            double normY = y / vectorNorm;
            double normZ = z / vectorNorm;
            return new UnitVector(normX, normY, normZ);
        }

        /// <summary>
        /// returns a direction cosine 1,0,0
        /// </summary>
        /// <returns></returns>
        public static UnitVector XDC()
        { return new UnitVector(1.0, 0.0, 0.0); }

        /// <summary>
        /// returns a direction cosine 0,1,0
        /// </summary>
        /// <returns></returns>
        public static UnitVector YDC()
        { return new UnitVector(0.0, 1.0, 0.0); }

        /// <summary>
        /// returns a direction cosine 0,0,1
        /// </summary>
        /// <returns></returns>
        public static UnitVector ZDC()
        { return new UnitVector(0.0, 0.0, 1.0); }

        public double X { get { return _x; } }

        public double Y { get { return _y; } }

        public double Z { get { return _z; } }
    }
}
