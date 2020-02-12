using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle;

namespace Trianlge.Tests
{

    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void IsRightTriangle()
        {
            Assert.IsTrue(TriangleClass.IsTriangle(5, 8, 10));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(TriangleClass.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(TriangleClass.IsTriangle(-5, -8, -10));
        }

        [TestMethod]
        public void IsTrianglePossible()
        {
            Assert.IsFalse(TriangleClass.IsTriangle(19, 10, 5));
        }

        [TestMethod]
        public void OneSideIsZero()
        {
            Assert.IsFalse(TriangleClass.IsTriangle(0, 3, 7));
        }

        [TestMethod]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(TriangleClass.IsTriangle(3, -4, 5));
        }

        [TestMethod]
        public void IsTriangleIsoscelesTriangle()
        {
            Assert.IsTrue(TriangleClass.IsTriangle(5, 5, 7));
        }

        [TestMethod]
        public void IsTriangleEquilateralTriangle()
        {
            Assert.IsTrue(TriangleClass.IsTriangle(5, 5, 5));
        }

        [TestMethod]
        public void IsAnotherRightTriangle()
        {
            Assert.IsTrue(TriangleClass.IsTriangle(4, 7, 10));
        }

        [TestMethod]
        public void IsAndAnotherRightTriangle()
        {
            Assert.IsTrue(TriangleClass.IsTriangle(2, 4, 6));
        }
    }
}
