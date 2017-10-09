using System;
using System.Collections.Generic;
using System.Text;

namespace CorodinateSystems
{
    /// <summary>
    /// The Unit vector is a vector where the magnitude is always 1
    /// </summary>
    public class UnitVector
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


        /// <summary>
        /// returns a direction cosine 1,0,0
        /// </summary>
        /// <returns></returns>
        public static UnitVector XDC()
        { return new UnitVector { X = 1, Y = 0, Z = 0 }; }

        /// <summary>
        /// returns a direction cosine 0,1,0
        /// </summary>
        /// <returns></returns>
        public static UnitVector YDC()
        { return new UnitVector { X = 0, Y = 1, Z = 0 }; }

        /// <summary>
        /// returns a direction cosine 0,0,1
        /// </summary>
        /// <returns></returns>
        public static UnitVector ZDC()
        { return new UnitVector { X = 0, Y = 0, Z = 1 }; }

    }
}
