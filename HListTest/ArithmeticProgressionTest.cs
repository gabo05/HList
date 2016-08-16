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
            var ap1 = new ArithmeticProgression(4D, null);
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
            var ap1 = new ArithmeticProgression(first: 2, nelement: 12, eleinter: 4, count: null);
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
            var ap1 = new ArithmeticProgression(nelement: 50, n: 12, difference: 4, count: null);
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
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 });
            var ap2 = new ArithmeticProgression(new double?[] { 4, 9 }, 7);
            var ap3 = new ArithmeticProgression(new double?[] { 4, null, null, 19});
            var ap4 = new ArithmeticProgression(new double?[] { 4, null, null, 19, null });
            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Difference, 5D);
            Assert.AreEqual(ap1.First(), 4D);
            Assert.AreEqual(ap1.GetElement(5), 29D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap2.Difference, 5D);
            Assert.AreEqual(ap2.First(), 4D);
            Assert.AreEqual(ap2.GetElement(5), 29D);

            Assert.IsFalse(ap3.IsInfinite);
            Assert.IsNotNull(ap3.Count());
            Assert.AreEqual(ap3.Difference, 5D);
            Assert.AreEqual(ap3.First(), 4D);
            Assert.AreEqual(ap3.GetElement(2), 14D);

            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
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
        [TestMethod]
        public void TestIndexOf() {
            //Arrange
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 });

            //Action
            var n = ap1.GetIndexOf(49);

            //Assert
            Assert.AreEqual(n, 9);
        }
        [TestMethod]
        public void SumTest() {
            //Arrange
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 });
            var ap2 = new ArithmeticProgression(new double?[] { 4, 8 }, 5);
            bool error = false;
            //Action
            try {
                double s = ap1.Sum();
            } catch (InvalidOperationException ex) {
                error = true;
            }
            double sum = ap2.Sum();

            //Assert
            Assert.IsTrue(error);
            Assert.AreEqual(sum, 60D);
        }
        [TestMethod]
        public void TestTake() {
            //Arrange
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 });

            //Action
            var t1 = ap1.Take(7);
            var t2 = ap1.Take(3, 7);

            //Assert
            Assert.IsInstanceOfType(t1, typeof(ArithmeticProgression));
            Assert.IsNotNull(t1);
            Assert.IsFalse(t1.IsInfinite);
            Assert.AreEqual(t1.Count(), 7);
            Assert.AreEqual(t1.First(), 4D);
            Assert.AreEqual(t1.Last(), 34D);

            Assert.IsInstanceOfType(t2, typeof(ArithmeticProgression));
            Assert.IsNotNull(t2);
            Assert.IsFalse(t2.IsInfinite);
            Assert.AreEqual(t2.Count(), 7);
            Assert.AreEqual(t2.First(), 19D);
            Assert.AreEqual(t2.Last(), 49D);
        }
        [TestMethod]
        public void TestTakeWhile() {
            //Arrange
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 });

            //Action
            var t1 = ap1.TakeWhile(x => x < 50);

            //Assert
            Assert.IsInstanceOfType(t1, typeof(ArithmeticProgression));
            Assert.IsNotNull(t1);
            Assert.IsFalse(t1.IsInfinite);
            Assert.AreEqual(t1.Count(), 10);
            Assert.AreEqual(t1.First(), 4D);
            Assert.AreEqual(t1.Last(), 49D);
        }
        [TestMethod]
        public void FoldLeftTest() {
            //Arrange
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 }, 5);

            //Action
            var fl1 = ap1.FoldLeft<double>((x, y) => y % 2 == 0 ? x + 2D : x - 1D);
            var fl2 = ap1.FoldLeft<double>((x, y) => y % 2 == 0 ? x + 2D : x - 1D, 3);
            var fl3 = ap1.FoldLeft<double>((x, y) => y % 2 == 0 ? x + 2D : x - 1D, 1, 3);

            //Assert
            Assert.IsInstanceOfType(fl1, typeof(double));
            Assert.AreEqual(fl1, 4D);

            Assert.IsInstanceOfType(fl2, typeof(double));
            Assert.AreEqual(fl2, 1D);

            Assert.IsInstanceOfType(fl3, typeof(double));
            Assert.AreEqual(fl3, 0D);
        }
        [TestMethod]
        public void FoldRightTest()
        {
            //Arrange
            var ap1 = new ArithmeticProgression(new double?[] { 4, 9 }, 5);

            //Action
            var fl1 = ap1.FoldRight<double>((x, y) => y % 2 == 0 && x == 0 ? y : x);
            var fl2 = ap1.FoldRight<double>((x, y) => y % 2 == 0 && x == 0 ? y : x, 3);
            var fl3 = ap1.FoldRight<double>((x, y) => y % 2 == 0 && x == 0 ? y : x, 3, 1);

            //Assert
            Assert.IsInstanceOfType(fl1, typeof(double));
            Assert.AreEqual(fl1, 24D);

            Assert.IsInstanceOfType(fl2, typeof(double));
            Assert.AreEqual(fl2, 14D);

            Assert.IsInstanceOfType(fl3, typeof(double));
            Assert.AreEqual(fl3, 14D);
        }
    }
}
