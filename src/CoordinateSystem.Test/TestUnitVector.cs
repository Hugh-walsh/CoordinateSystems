using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestUnitVector
    {
        /// <summary>
        /// Here is an example summary of the class. 
        /// Turn on XML documentation generator in project properties
        /// </summary>
        [TestMethod]
        public void TestCreate()
        {
            var unitX = UnitVector.XDC();
            Assert.AreEqual(1.0, unitX.X);
            Assert.AreEqual(0.0, unitX.Y);
            Assert.AreEqual(0.0, unitX.Z);

            var unitY = UnitVector.YDC();
            Assert.AreEqual(0.0, unitY.X);
            Assert.AreEqual(1.0, unitY.Y);
            Assert.AreEqual(0.0, unitY.Z);

            var unitZ = UnitVector.ZDC();
            Assert.AreEqual(0.0, unitZ.X);
            Assert.AreEqual(0.0, unitZ.Y);
            Assert.AreEqual(1.0, unitZ.Z);

            var unitArb = UnitVector.FromArbitraryOrdinates(x: Math.Sqrt(3.0), y: Math.Sqrt(3.0), z: Math.Sqrt(3.0));
            Assert.AreEqual(expected: Math.Sqrt(3.0) / 3.0, actual: unitArb.X, delta: 0.0001);
            Assert.AreEqual(expected: Math.Sqrt(3.0) / 3.0, actual: unitArb.Y, delta: 0.0001);
            Assert.AreEqual(expected: Math.Sqrt(3.0) / 3.0, actual: unitArb.Z, delta: 0.0001);
        }
    }
}
