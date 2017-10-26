using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinateSystems
{
    /// <summary>
    /// A vector can be any magnitude and it represents a transpose between 2 points.  
    /// </summary>
    public class Vector : AbstractVector
    {
        public Vector(double x, double y, double z) : base(x, y, z) {}

    }
}
