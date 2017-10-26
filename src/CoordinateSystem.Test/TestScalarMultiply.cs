using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    class TestScalarMultiply
    {
        [TestMethod]
        public void TestScalarMultiplyVector()
        {
            Vector vectorA = new Vector(x: 1.0, y: 1.0, z: 1.0);
            Vector vectorB = 5 * vectorA;

            Assert.IsInstanceOfType(value: vectorB, expectedType: typeof(Vector));
        }
    }
}
