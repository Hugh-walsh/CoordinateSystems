using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestPoint
    {
        [TestMethod]
        public void TestCreate()
        {
            Point point = new Point();
            Assert.AreEqual(0.0, point.X);
            Assert.AreEqual(0.0, point.Y);
            Assert.AreEqual(0.0, point.Z);
        }
    }
}
