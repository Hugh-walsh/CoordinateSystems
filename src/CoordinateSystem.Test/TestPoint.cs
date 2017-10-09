using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorodinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestPoint
    {
        [TestMethod]
        public void TestDefault()
        {
            var point = new Point();
            Assert.AreEqual(0.0, point.X);
            Assert.AreEqual(0.0, point.Y);
            Assert.AreEqual(0.0, point.Z);
        }
    }
}
