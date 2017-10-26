using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateSystems;

namespace CoordinateSystem.Test
{
    [TestClass]
    public class TestVector
    {
        [TestMethod]
        public void TestCreate()
        {
            Vector vector = new Vector(x: 0.0, y: 0.0, z: 0.0);
            Assert.AreEqual(0.0, vector.X);
            Assert.AreEqual(0.0, vector.Y);
            Assert.AreEqual(0.0, vector.Z);
        }

        [TestMethod]
        public void TestVectorAddition()
        {
            Vector vectorA = new Vector(x: 1, y: 1, z: 1);
            Vector vectorB = new Vector(x: 1, y: 1, z: 1);
            Vector addVector = vectorA + vectorB;
            Vector reverseAddVector = vectorB + vectorA;

            Assert.IsInstanceOfType(addVector, typeof(Vector));
            Assert.IsInstanceOfType(reverseAddVector, typeof(Vector));

            Assert.IsTrue(addVector.X == 2 & addVector.Y == 2 & addVector.Z ==2);
            Assert.IsTrue(reverseAddVector.X == 2 & reverseAddVector.Y == 2 & reverseAddVector.Z == 2);
        }

        [TestMethod]
        public void TestCreateFromPoints()
        {
            Point pointA = new Point {_x = 2.0, _y = 2.0, _z = 2.0};
            Point pointB = new Point { _x = 3.0, _y = 3.0, _z = 3.0 };
            Vector vector = pointB - pointA;

            Assert.IsInstanceOfType(vector, typeof(Vector));

            Assert.IsTrue(vector.X == 1.0 & vector.Y == 1.0 & vector.Z == 1.0);
        }
    }
}