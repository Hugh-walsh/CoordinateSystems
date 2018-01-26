using System;
using System.Collections.Generic;
using System.Text;
// add ability to stack stransforms to spit out a new transform.
// tranform should be 4x4. 3x3 rotation, 3x1 translate, 1x3 skew + 1 homogeneous coord

namespace CoordinateSystems
{
    /// <summary>
    /// The transformation matrix or coordinate system
    /// </summary>
    public class Frame

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
