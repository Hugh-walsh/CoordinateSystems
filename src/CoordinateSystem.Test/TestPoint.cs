using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestPoint
    {
        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(1, 21, 3)]
        [DataRow(11, 2, 3)]
        public void TestCreate(double x, double y, double z)
        {
            Point point = new Point(x,y,z);
            Assert.AreEqual(x, point._x);
            Assert.AreEqual(y, point._y);
            Assert.AreEqual(z, point._z);
        }
    }
}
