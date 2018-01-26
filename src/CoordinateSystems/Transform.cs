using System;

namespace CoordinateSystems
{
    /// <summary>
    /// A HomogeneousTransform implements a 4x4 homogeneous coordinate-transform.
    /// Homogeneous means all skew entries are 0 and the homogeneous coordinate is 1.
    /// 
    /// [  Scale_x    Rotate_xy  Rotate_zx  Translate_x ]
    /// [  Rotate_yx  Scale_y    Rotate_yz  Translate_y ]
    /// [  Rotate_zx  Rotate_yz  Scale_z    Translate_z ]
    /// [  Skew_x     Skew_y     Skew_z     Homo        ]
    /// </summary>
    public class HomogeneousTransform
    {
        #region Public Fields
        /// <summary>
        /// Value at row 1, column 1 of the matrix.
        /// </summary>
        public readonly double scale_x;
        /// <summary>
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public readonly double rotation_xy;
        /// <summary>
        /// Value at row 1, column 3 of the matrix.
        /// </summary>
        public readonly double rotation_xz;
        /// <summary>
        /// Value at row 1, column 4 of the matrix.
        /// </summary>
        public readonly double translation_x;
        /// <summary>
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public readonly double rotation_yx;
        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public readonly double scale_y;
        /// <summary>
        /// Value at row 2, column 3 of the matrix.
        /// </summary>
        public readonly double rotation_yz;
        /// <summary>
        /// Value at row 2, column 4 of the matrix.
        /// </summary>
        public readonly double translation_y;

        /// <summary>
        /// Value at row 3, column 1 of the matrix.
        /// </summary>
        public readonly double rotation_zx;
        /// <summary>
        /// Value at row 3, column 2 of the matrix.
        /// </summary>
        public readonly double rotation_zy;
        /// <summary>
        /// Value at row 3, column 3 of the matrix.
        /// </summary>
        public readonly double scale_z;
        /// <summary>
        /// Value at row 3, column 4 of the matrix.
        /// </summary>
        public readonly double translation_z;

        /// <summary>
        /// Value at row 4, column 1 of the matrix.
        /// </summary>
        public readonly double skew_x;
        /// <summary>
        /// Value at row 4, column 2 of the matrix.
        /// </summary>
        public readonly double skew_y;
        /// <summary>
        /// Value at row 4, column 3 of the matrix.
        /// </summary>
        public readonly double skew_z;
        /// <summary>
        /// Value at row 4, column 4 of the matrix.
        /// </summary>
        public readonly double homogeneous_coord;
        #endregion Public Fields


        public HomogeneousTransform(
                         double scale_x = 1, double rotation_xy = 0, double rotation_xz = 0, double translation_x = 0,
                         double rotation_yx = 0, double scale_y = 1, double rotation_yz = 0, double translation_y = 0,
                         double rotation_zx = 0, double rotation_zy = 0, double scale_z = 1, double translation_z = 0)
        {
            this.scale_x = scale_x;
            this.rotation_xy = rotation_xy;
            this.rotation_xz = rotation_xz;
            this.translation_x = translation_x;

            this.rotation_yx = rotation_yx;
            this.scale_y = scale_y;
            this.rotation_yz = rotation_yz;
            this.translation_y = translation_y;

            this.rotation_zx = rotation_zx;
            this.rotation_zy = rotation_zy;
            this.scale_z = scale_z;
            this.translation_z = translation_z;

            this.skew_x = 0;
            this.skew_y = 0;
            this.skew_z = 0;
            this.homogeneous_coord = 1;
        }

        public static HomogeneousTransform Identity = new HomogeneousTransform();

        public HomogeneousTransform Translation(double x, double y, double z)
        {
            // [  1  0  0  x ]
            // [  0  1  0  y ]
            // [  0  0  1  z ]
            // [  0  0  0  1 ]

            HomogeneousTransform translation = new HomogeneousTransform(translation_x: x, translation_y: y, translation_z: z);
            return translation * this;
        }


        public HomogeneousTransform RotationX(double radians)
        {
            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]

            double c = Math.Cos(radians);
            double s = Math.Sin(radians);

            HomogeneousTransform rotationX = new HomogeneousTransform(scale_y: c,
                                                                      scale_z: c,
                                                                      rotation_xz: s,
                                                                      rotation_yz: -s);

            return rotationX * this;
        }

        public HomogeneousTransform RotationY(double radians)
        {
            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  0  0  0  1 ]

            double c = Math.Cos(radians);
            double s = Math.Sin(radians);

            HomogeneousTransform rotationY = new HomogeneousTransform(scale_x: c,
                                                                      scale_z: c,
                                                                      rotation_zx: -s,
                                                                      rotation_xz: s);

            return rotationY * this;
        }

        public HomogeneousTransform RotationZ(double radians)
        {
            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  0  0  0  1 ]

            double c = Math.Cos(radians);
            double s = Math.Sin(radians);

            HomogeneousTransform rotationZ = new HomogeneousTransform(scale_x: c,
                                                                      scale_y: c,
                                                                      rotation_yx: s,
                                                                      rotation_xy: -s);

            return rotationZ * this;
        }

  
        /// <summary>
        /// Multiplies a Transform by another Transform.
        /// </summary>
        /// <param name="transformA">The first source matrix.</param>
        /// <param name="transformB">The second source matrix.</param>
        /// <returns>The result Transform Object.</returns>
        public static HomogeneousTransform operator *(HomogeneousTransform transformA, HomogeneousTransform transformB)
        {

            // First row
            double scale_x = transformA.scale_x * transformB.scale_x + transformA.rotation_xy * transformB.rotation_yx + transformA.rotation_xz * transformB.rotation_zx + transformA.translation_x * transformB.skew_x;
            double rotation_xy = transformA.scale_x * transformB.rotation_xy + transformA.rotation_xy * transformB.scale_y + transformA.rotation_xz * transformB.rotation_zy + transformA.translation_x * transformB.skew_y;
            double rotation_xz = transformA.scale_x * transformB.rotation_xz + transformA.rotation_xy * transformB.rotation_yz + transformA.rotation_xz * transformB.scale_z + transformA.translation_x * transformB.skew_z;
            double translation_x = transformA.scale_x * transformB.translation_x + transformA.rotation_xy * transformB.translation_y + transformA.rotation_xz * transformB.translation_z + transformA.translation_x * transformB.homogeneous_coord;

            // Second row
            double rotation_yx = transformA.rotation_yx * transformB.scale_x + transformA.scale_y * transformB.rotation_yx + transformA.rotation_yz * transformB.rotation_zx + transformA.translation_y * transformB.skew_x;
            double scale_y = transformA.rotation_yx * transformB.rotation_xy + transformA.scale_y * transformB.scale_y + transformA.rotation_yz * transformB.rotation_zy + transformA.translation_y * transformB.skew_y;
            double rotation_yz = transformA.rotation_yx * transformB.rotation_xz + transformA.scale_y * transformB.rotation_yz + transformA.rotation_yz * transformB.scale_z + transformA.translation_y * transformB.skew_z;
            double translation_y = transformA.rotation_yx * transformB.translation_x + transformA.scale_y * transformB.translation_y + transformA.rotation_yz * transformB.translation_z + transformA.translation_y * transformB.homogeneous_coord;

            // Third row
            double rotation_zx = transformA.rotation_zx * transformB.scale_x + transformA.rotation_zy * transformB.rotation_yx + transformA.scale_z * transformB.rotation_zx + transformA.translation_z * transformB.skew_x;
            double rotation_zy = transformA.rotation_zx * transformB.rotation_xy + transformA.rotation_zy * transformB.scale_y + transformA.scale_z * transformB.rotation_zy + transformA.translation_z * transformB.skew_y;
            double scale_z = transformA.rotation_zx * transformB.rotation_xz + transformA.rotation_zy * transformB.rotation_yz + transformA.scale_z * transformB.scale_z + transformA.translation_z * transformB.skew_z;
            double translation_z = transformA.rotation_zx * transformB.translation_x + transformA.rotation_zy * transformB.translation_y + transformA.scale_z * transformB.translation_z + transformA.translation_z * transformB.homogeneous_coord;
            
            // Fourth row (Calculated but unused as these will always be 0,0,0,1 for orthogonal coordinates)
            double skew_x = transformA.skew_x * transformB.scale_x + transformA.skew_y * transformB.rotation_yx + transformA.skew_z * transformB.rotation_zx + transformA.homogeneous_coord * transformB.skew_x;
            double skew_y = transformA.skew_x * transformB.rotation_xy + transformA.skew_y * transformB.scale_y + transformA.skew_z * transformB.rotation_zy + transformA.homogeneous_coord * transformB.skew_y;
            double skew_z = transformA.skew_x * transformB.rotation_xz + transformA.skew_y * transformB.rotation_yz + transformA.skew_z * transformB.scale_z + transformA.homogeneous_coord * transformB.skew_z;
            double homogeneous_coord = transformA.skew_x * transformB.translation_x + transformA.skew_y * transformB.translation_y + transformA.skew_z * transformB.translation_z + transformA.homogeneous_coord * transformB.homogeneous_coord;

            return new HomogeneousTransform
            (
                scale_x, rotation_xy, rotation_xz, translation_x,
                rotation_yx, scale_y, rotation_yz, translation_y,
                rotation_zx, rotation_zy, scale_z, translation_z
            );
        }

        public static IVector operator *(HomogeneousTransform transform, IVector vector)
        {

            return UnitVector.XDC();

        }

        ///Make a function for both points and vectors multiply




        /// <summary>
        /// Is a transform equvalent to another? i.e. given a test point do both transforms have the same effect?.
        /// So, (T1 * Point)
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this matrix; False otherwise.</returns>
        public override bool Equals(object obj)
        {

            if (obj is HomogeneousTransform)
            {
                return Equals((HomogeneousTransform)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return scale_x.GetHashCode() + rotation_xy.GetHashCode() + rotation_xz.GetHashCode() + translation_x.GetHashCode() +
                   rotation_yx.GetHashCode() + scale_y.GetHashCode() + rotation_yz.GetHashCode() + translation_y.GetHashCode() +
                   rotation_zx.GetHashCode() + rotation_zy.GetHashCode() + scale_z.GetHashCode() + translation_z.GetHashCode() +
                   skew_x.GetHashCode() + skew_y.GetHashCode() + skew_z.GetHashCode() + homogeneous_coord.GetHashCode();
        }
    }
}

