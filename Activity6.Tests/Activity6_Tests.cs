using CSharp.Activity.Polymorphism;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Activity6.Tests
{
    [TestClass]
    public class Activity6_Tests
    {
        [TestMethod]
        public void TestRectangleArea0()
        {
            Rectangle rect = new(0, 0);
            Assert.AreEqual(0d, rect.Length);
            Assert.AreEqual(0d, rect.Width);

            rect.CalculateArea();
            Assert.AreEqual(0d, rect.Area);

            rect.Print();
        }

        [TestMethod]
        public void TestRectangleArea1()
        {
            Rectangle rect = new(10, 20);
            Assert.AreEqual(10d, rect.Length);
            Assert.AreEqual(20d, rect.Width);

            rect.CalculateArea();
            Assert.AreEqual(200d, rect.Area);

            rect.Print();
        }

        [TestMethod]
        public void TestRectangleArea2()
        {
            Rectangle rect = new(20, 15);
            Assert.AreEqual(20d, rect.Length);
            Assert.AreEqual(15d, rect.Width);

            rect.CalculateArea();
            Assert.AreEqual(300d, rect.Area);

            rect.Print();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestRectangleNegativeLength()
        {
            _ = new Rectangle(-1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestRectangleNegativeWidth()
        {
            _ = new Rectangle(10, -1);
        }

        [TestMethod]
        public void TestCircleArea0()
        {
            Circle circle = new(0);
            Assert.AreEqual(0d, circle.Radius);

            circle.CalculateArea();
            Assert.AreEqual(0d, circle.Area);

            circle.Print();
        }

        [TestMethod]
        public void TestCircleArea1()
        {
            Circle circle = new(10);
            Assert.AreEqual(10d, circle.Radius);

            circle.CalculateArea();
            Assert.AreEqual(System.Math.PI * 10 * 10, circle.Area);

            circle.Print();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestCircleNegativeRadius()
        {
            _ = new Circle(-1);
        }
    }
}