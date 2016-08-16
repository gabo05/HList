using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HList.Progression;

namespace HListTest
{
    [TestClass]
    public class ArithmeticProgressionTest
    {
        [TestMethod]
        public void Constructor1Test()
        {
            //Action
            var ap1 = new ArithmeticProgression();
            var ap2 = new ArithmeticProgression(3D);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Difference, 1D);
            Assert.AreEqual(ap1.First(), 0D);
            Assert.AreEqual(ap1.GetElement(6), 6D);

            Assert.IsTrue(ap2.IsInfinite);
            Assert.IsNull(ap2.Count());
            Assert.AreEqual(ap2.Difference, 3D);
            Assert.AreEqual(ap2.First(), 0D);
            Assert.AreEqual(ap2.GetElement(6), 18D);
        }
        [TestMethod]
        public void Constructor2Test()
        {
            //Action
            var ap1 = new ArithmeticProgression(first: 4);
            var ap2 = new ArithmeticProgression(first: 4, difference: 2);
            var ap3 = new ArithmeticProgression(first: 4, count: 7);
            var ap4 = new ArithmeticProgression(first: 4, difference: 2, count: 7);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Difference, 1D);
            Assert.AreEqual(ap1.First(), 4D);
            Assert.AreEqual(ap1.GetElement(6), 10D);

            Assert.IsTrue(ap2.IsInfinite);
            Assert.IsNull(ap2.Count());
            Assert.AreEqual(ap2.Difference, 2D);
            Assert.AreEqual(ap2.First(), 4D);
            Assert.AreEqual(ap2.GetElement(6), 16D);

            Assert.IsFalse(ap3.IsInfinite);
            Assert.IsNotNull(ap3.Count());
            Assert.AreEqual(ap3.Difference, 1D);
            Assert.AreEqual(ap3.First(), 4D);
            Assert.AreEqual(ap3.GetElement(6), 10D);

            try
            {
                ap3.GetElement(8);
                Assert.IsTrue(false);
            }
            catch (IndexOutOfRangeException)
            {

                Assert.IsTrue(true);
            }

            Assert.IsFalse(ap4.IsInfinite);
            Assert.IsNotNull(ap4.Count());
            Assert.AreEqual(ap4.Difference, 2D);
            Assert.AreEqual(ap4.First(), 4D);
            Assert.AreEqual(ap4.GetElement(6), 16D);

            try
            {
                ap4.GetElement(8);
                Assert.IsTrue(false);
            }
            catch (IndexOutOfRangeException)
            {

                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void Constructor3Test()
        {
            var ap1 = new ArithmeticProgression(first: 2, nelement: 12, eleinter: 4);
            var ap2 = new ArithmeticProgression(first: 2, nelement: 12, eleinter: 4, count: 9);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Difference, 2D);
            Assert.AreEqual(ap1.First(), 2D);
            Assert.AreEqual(ap1.GetElement(5), 12D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap2.Difference, 2D);
            Assert.AreEqual(ap2.First(), 2D);
            Assert.AreEqual(ap2.GetElement(4), 10D);

            try
            {
                ap2.GetElement(10);
                Assert.IsTrue(false);
            }
            catch (IndexOutOfRangeException)
            {

                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void Constructor4Test()
        {
            var ap1 = new ArithmeticProgression(nelement: 50, n: 12, difference: 4);
            var ap2 = new ArithmeticProgression(nelement: 50, n: 12, difference: 4, count: 9);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Difference, 4D);
            Assert.AreEqual(ap1.First(), 2D);
            Assert.AreEqual(ap1.GetElement(5), 22D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap1.Difference, 4D);
            Assert.AreEqual(ap1.First(), 2D);
            Assert.AreEqual(ap1.GetElement(5), 22D);

            try
            {
                ap2.GetElement(10);
                Assert.IsTrue(false);
            }
            catch (IndexOutOfRangeException)
            {

                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void Constructor5Test()
        {
            var ap1 = new ArithmeticProgression(new double[] { 4, 9 });
            var ap2 = new ArithmeticProgression(new double[] { 4, 9 }, 7);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Difference, 5D);
            Assert.AreEqual(ap1.First(), 4D);
            Assert.AreEqual(ap1.GetElement(5), 29D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap1.Difference, 5D);
            Assert.AreEqual(ap1.First(), 4D);
            Assert.AreEqual(ap1.GetElement(5), 29D);

            try
            {
                ap2.GetElement(10);
                Assert.IsTrue(false);
            }
            catch (IndexOutOfRangeException)
            {

                Assert.IsTrue(true);
            }
        }
    }
}
