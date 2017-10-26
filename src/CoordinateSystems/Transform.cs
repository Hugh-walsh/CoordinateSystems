using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinateSystems
{
    /// <summary>
    /// The transformation matrix or coordinate system
    /// </summary>
    public class Transform

    {
        /// <summary>
        /// Direction cosine in the X direction
        /// </summary>
        public UnitVector I = UnitVector.XDC();
        /// <summary>
        /// Direction cosine in the Y direction
        /// </summary>
        public UnitVector J = UnitVector.YDC();
        /// <summary>
        /// Direction cosine in the Z direction
        /// </summary>
        public UnitVector K = UnitVector.ZDC();

        /// <summary>
        /// The fixed point origin of the t
        /// </summary>
        public Point Origin = new Point();
    }
}
