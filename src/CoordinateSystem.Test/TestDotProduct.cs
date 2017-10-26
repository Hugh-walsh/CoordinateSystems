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
            double dotProductXY = Vector.DotProduct(unitX, unitY);
            double dotProductYZ = Vector.DotProduct(unitY, unitZ);
            double dotProductXX = Vector.DotProduct(unitX, unitX);
            Assert.AreEqual(expected: 0.0, actual: dotProductXY);
            Assert.AreEqual(expected: 0.0, actual: dotProductYZ);
            Assert.AreEqual(expected: 1.0, actual: dotProductXX);
        }

        //[DataTestMethod]
        //[DataRow(0, 1, 0, 0, 1, 2, 3)]
        //public void TestUnitaryaVectors (double expected, double xa, double ya, double za, UnitVector unitY)
        //{
        //    var unitX = new UnitVector();
        //    var unitY = new UnitVector();

        //    double dotProductXY = Vector.DotProduct(unitX, unitY);
        //    Assert.AreEqual(expected: expected, actual: dotProductXY);
        //}

        [TestMethod]
        public void TestVectors()
        {
            Vector vectorA = new Vector(x: 1, y: 1, z: 1);
            Vector vectorB = new Vector(x: 1, y: 1, z: 1);
            double dotProduct = Vector.DotProduct(vectorA, vectorB);

            Assert.AreEqual(expected: 3.0, actual: dotProduct);

        }

    }
}
