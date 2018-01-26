using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestTransform
    {

        [TestMethod]
        public void TestCanCreateAbritrary()
        {
            HomogeneousTransform newTransform = new HomogeneousTransform(translation_x: 1,
                                                                         translation_y: 1,
                                                                         translation_z: 1,
                                                                         scale_x: 1,
                                                                         scale_y: 1,
                                                                         scale_z: 1,
                                                                         rotation_xy: 1,
                                                                         rotation_xz: 1,
                                                                         rotation_yx: 1,
                                                                         rotation_yz: 1,
                                                                         rotation_zx: 1,
                                                                         rotation_zy: 1);



            Assert.IsInstanceOfType(newTransform, typeof(HomogeneousTransform));
        }


        [TestMethod]
        public void TestCanCreateIdentity()
        {
            HomogeneousTransform newIdentityTransform = HomogeneousTransform.Identity;
            Assert.IsInstanceOfType(newIdentityTransform, typeof(HomogeneousTransform));

        }

        [TestMethod]
        public void TestCanCreateTranslation()
        {
            HomogeneousTransform translation = HomogeneousTransform.Identity.Translation(x: 2, y: 2, z: 2);
            Assert.IsInstanceOfType(translation, typeof(HomogeneousTransform));
            Assert.AreEqual(translation.translation_x, 2.0);
            Assert.AreEqual(translation.translation_y, 2.0);
            Assert.AreEqual(translation.translation_z, 2.0);
        }

        [TestMethod]
        public void TestCanCreateRotationX()
        {
            HomogeneousTransform transform = HomogeneousTransform.Identity.RotationX(radians: Math.PI);
            Assert.IsInstanceOfType(transform, typeof(HomogeneousTransform));
            Assert.AreEqual(transform.translation_x, 0.0);
            Assert.AreEqual(transform.translation_y, 0.0);
            Assert.AreEqual(transform.translation_z, 0.0);
            Assert.AreEqual(transform.scale_y, -1);
            Assert.AreEqual(transform.scale_z, -1);
            Assert.AreEqual(expected: transform.rotation_yz, actual: 0.0, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_zy, actual: 0.0, delta: 0.1);
        }

        [TestMethod]
        public void TestCanCreateRotationY()
        {
            HomogeneousTransform transform = HomogeneousTransform.Identity.RotationY(radians: Math.PI);
            Assert.IsInstanceOfType(transform, typeof(HomogeneousTransform));
            Assert.AreEqual(transform.translation_x, 0.0);
            Assert.AreEqual(transform.translation_y, 0.0);
            Assert.AreEqual(transform.translation_z, 0.0);
            Assert.AreEqual(transform.scale_x, -1);
            Assert.AreEqual(transform.scale_z, -1);
            Assert.AreEqual(expected: transform.rotation_xz, actual: 0.0, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_zx, actual: 0.0, delta: 0.1);
        }

        [TestMethod]
        public void TestCanCreateRotationZ()
        {
            HomogeneousTransform transform = HomogeneousTransform.Identity.RotationZ(radians: Math.PI);
            Assert.IsInstanceOfType(transform, typeof(HomogeneousTransform));
            Assert.AreEqual(transform.translation_x, 0.0);
            Assert.AreEqual(transform.translation_y, 0.0);
            Assert.AreEqual(transform.translation_z, 0.0);
            Assert.AreEqual(transform.scale_x, -1);
            Assert.AreEqual(transform.scale_y, -1);
            Assert.AreEqual(expected: transform.rotation_xy, actual: 0.0, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_yx, actual: 0.0, delta: 0.1);
        }

        [TestMethod]
        public void TestCanCreateMultiTransform()
        {
            HomogeneousTransform transform = HomogeneousTransform.Identity.RotationZ(1.3*Math.PI).Translation(0.5, 0.7, 0.8).RotationY(1.7*Math.PI).RotationX(1.4*Math.PI);
            Assert.IsInstanceOfType(transform, typeof(HomogeneousTransform));
            Assert.AreEqual(expected: transform.translation_x, actual: -1.185, delta: 0.1);
            Assert.AreEqual(expected: transform.translation_y, actual: 0.616, delta: 0.1);
            Assert.AreEqual(expected: transform.translation_z, actual: -0.27, delta: 0.1);
            Assert.AreEqual(expected: transform.scale_x, actual: 0.107, delta: 0.1);
            Assert.AreEqual(expected: transform.scale_y, actual: 0.804, delta: 0.1);
            Assert.AreEqual(expected: transform.scale_z, actual: -0.18, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_xy, actual: -0.15, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_yx, actual: -0.202, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_xy, actual: -0.15, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_yx, actual: -0.202, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_xy, actual: -0.15, delta: 0.1);
            Assert.AreEqual(expected: transform.rotation_yx, actual: -0.202, delta: 0.1);
        }

        [TestMethod]
        public void TestCanTransformVector()
        {
            HomogeneousTransform translation = HomogeneousTransform.Identity.Translation(x: 2, y: 2, z: 2);
            Assert.IsInstanceOfType(translation, typeof(HomogeneousTransform));
            Vector newVector = new Vector(1, 2, 3);
            Vector transformedVector = translation * newVector;
            Assert.AreEqual(translation.translation_x, 2.0);
            Assert.AreEqual(translation.translation_y, 2.0);
            Assert.AreEqual(translation.translation_z, 5.0);
        }
    }
}
