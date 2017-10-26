using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestDotProduct
    {
        [TestMethod]
        public void TestUnitaryVectors()
        {
            UnitVector unitX = UnitVector.XDC();
            UnitVector unitY = UnitVector.YDC();
            UnitVector unitZ = UnitVector.ZDC();
            double dotProductXY = unitX.DotProduct(unitY);
            double dotProductYZ = unitY.DotProduct(unitZ);
            double dotProductXX = unitX.DotProduct(unitX);
            Assert.AreEqual(expected: 0.0, actual: dotProductXY);
            Assert.AreEqual(expected: 0.0, actual: dotProductYZ);
            Assert.AreEqual(expected: 1.0, actual: dotProductXX);
        }

        [TestMethod]
        public void TestVectors()
        {
            Vector vectorA = new Vector(x: 1, y: 1, z: 1);
            Vector vectorB = new Vector(x: 1, y: 1, z: 1);
            double dotProduct = vectorA.DotProduct(vectorB);

            Assert.AreEqual(expected: 3.0, actual: dotProduct);

        }

    }
}
