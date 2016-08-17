using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HList.Progression;

namespace HListTest
{
    [TestClass]
    public class GeometricProgressionTest
    {
        [TestMethod]
        public void Constructor1Test()
        {
            //Action
            var ap1 = new GeometricProgression();
            var ap2 = new GeometricProgression(3D);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Ratio, 1D);
            Assert.AreEqual(ap1.First(), 1D);
            Assert.AreEqual(ap1.GetElement(6), 1D);

            Assert.IsTrue(ap2.IsInfinite);
            Assert.IsNull(ap2.Count());
            Assert.AreEqual(ap2.Ratio, 3D);
            Assert.AreEqual(ap2.First(), 1D);
            Assert.AreEqual(ap2.GetElement(6), 729D);
        }
        [TestMethod]
        public void Constructor2Test()
        {
            //Action
            var ap1 = new GeometricProgression(4D, null);
            var ap2 = new GeometricProgression(first: 4, ratio: 2);
            var ap3 = new GeometricProgression(first: 4, count: 7);
            var ap4 = new GeometricProgression(first: 4, ratio: 2, count: 7);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Ratio, 1D);
            Assert.AreEqual(ap1.First(), 4D);
            Assert.AreEqual(ap1.GetElement(6), 4D);

            Assert.IsTrue(ap2.IsInfinite);
            Assert.IsNull(ap2.Count());
            Assert.AreEqual(ap2.Ratio, 2D);
            Assert.AreEqual(ap2.First(), 4D);
            Assert.AreEqual(ap2.GetElement(6), 256D);

            Assert.IsFalse(ap3.IsInfinite);
            Assert.IsNotNull(ap3.Count());
            Assert.AreEqual(ap3.Ratio, 1D);
            Assert.AreEqual(ap3.First(), 4D);
            Assert.AreEqual(ap3.GetElement(6), 4D);

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
            Assert.AreEqual(ap4.Ratio, 2D);
            Assert.AreEqual(ap4.First(), 4D);
            Assert.AreEqual(ap4.GetElement(6), 256D);

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
            var ap1 = new GeometricProgression(first: 2, nelement: 162, eleinter: 3, count: null);
            var ap2 = new GeometricProgression(first: 2, nelement: 162, eleinter: 3, count: 9);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Ratio, 3D);
            Assert.AreEqual(ap1.First(), 2D);
            Assert.AreEqual(ap1.GetElement(5), 486D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap2.Ratio, 3D);
            Assert.AreEqual(ap2.First(), 2D);
            Assert.AreEqual(ap2.GetElement(4), 162D);

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
            var ap1 = new GeometricProgression(nelement: 54, n: 3, ratio: 3, count: null);
            var ap2 = new GeometricProgression(nelement: 54, n: 3, ratio: 3, count: 9);

            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Ratio, 3D);
            Assert.AreEqual(ap1.First(), 2D);
            Assert.AreEqual(ap1.GetElement(5), 486D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap1.Ratio, 3D);
            Assert.AreEqual(ap1.First(), 2D);
            Assert.AreEqual(ap1.GetElement(5), 486D);

            try
            {
                ap2.GetElement(10);
                Assert.IsTrue(false);
            }
            catch (IndexOutOfRangeException ex)
            {

                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void Constructor5Test()
        {
            var ap1 = new GeometricProgression(new double?[] { 3, 9 });
            var ap2 = new GeometricProgression(new double?[] { 3, 9 }, 7);
            var ap3 = new GeometricProgression(new double?[] { 3, null, null, 81 });
            var ap4 = new GeometricProgression(new double?[] { 3, null, null, 81, null });
            //Assert
            Assert.IsTrue(ap1.IsInfinite);
            Assert.IsNull(ap1.Count());
            Assert.AreEqual(ap1.Ratio, 3D);
            Assert.AreEqual(ap1.First(), 3D);
            Assert.AreEqual(ap1.GetElement(5), 729D);

            Assert.IsFalse(ap2.IsInfinite);
            Assert.IsNotNull(ap2.Count());
            Assert.AreEqual(ap2.Ratio, 3D);
            Assert.AreEqual(ap2.First(), 3D);
            Assert.AreEqual(ap2.GetElement(5), 729D);

            Assert.IsFalse(ap3.IsInfinite);
            Assert.IsNotNull(ap3.Count());
            Assert.AreEqual(ap3.Ratio, 3D);
            Assert.AreEqual(ap3.First(), 3D);
            Assert.AreEqual(ap3.GetElement(2), 27D);

            Assert.IsTrue(ap4.IsInfinite);
            Assert.IsNull(ap4.Count());
            Assert.AreEqual(ap4.Ratio, 3D);
            Assert.AreEqual(ap4.First(), 3D);
            Assert.AreEqual(ap4.GetElement(5), 729D);
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
        public void TestIndexOf()
        {
            //Arrange
            var ap1 = new GeometricProgression(new double?[] { 4, 16 });

            //Action
            var n = ap1.GetIndexOf(262144);

            //Assert
            Assert.AreEqual(n, 8);
        }
        [TestMethod]
        public void SumTest()
        {
            //Arrange
            var ap1 = new GeometricProgression(new double?[] { 4, 8 });
            var ap2 = new GeometricProgression(new double?[] { 4, 8 }, 5);
            bool error = false;
            //Action
            try
            {
                double s = ap1.Sum();
            }
            catch (InvalidOperationException ex)
            {
                error = true;
            }
            double sum = ap2.Sum();

            //Assert
            Assert.IsTrue(error);
            Assert.AreEqual(sum, 124D);
        }
        [TestMethod]
        public void TestTake()
        {
            //Arrange
            var ap1 = new GeometricProgression(new double?[] { 4, 16 });

            //Action
            var t1 = ap1.Take(7);
            var t2 = ap1.Take(3, 7);

            //Assert
            Assert.IsInstanceOfType(t1, typeof(GeometricProgression));
            Assert.IsNotNull(t1);
            Assert.IsFalse(t1.IsInfinite);
            Assert.AreEqual(t1.Count(), 7);
            Assert.AreEqual(t1.First(), 4D);
            Assert.AreEqual(t1.Last(), 16384D);

            Assert.IsInstanceOfType(t2, typeof(GeometricProgression));
            Assert.IsNotNull(t2);
            Assert.IsFalse(t2.IsInfinite);
            Assert.AreEqual(t2.Count(), 7);
            Assert.AreEqual(t2.First(), 256D);
            Assert.AreEqual(t2.Last(), 1048576D);
        }
        [TestMethod]
        public void TestTakeWhile()
        {
            //Arrange
            var ap1 = new GeometricProgression(new double?[] { 4, 8 });

            //Action
            var t1 = ap1.TakeWhile(x => x < 50);

            //Assert
            Assert.IsInstanceOfType(t1, typeof(GeometricProgression));
            Assert.IsNotNull(t1);
            Assert.IsFalse(t1.IsInfinite);
            Assert.AreEqual(t1.Count(), 4);
            Assert.AreEqual(t1.First(), 4D);
            Assert.AreEqual(t1.Last(), 32D);
        }
        [TestMethod]
        public void FoldLeftTest()
        {
            //Arrange
            var ap1 = new GeometricProgression(new double?[] { 4, 8 }, 5);

            //Action
            var fl1 = ap1.FoldLeft<double>((x, y) => y % 2 == 0 ? x + 2D : x - 1D);
            var fl2 = ap1.FoldLeft<double>((x, y) => y % 2 == 0 ? x + 2D : x - 1D, 3);
            var fl3 = ap1.FoldLeft<double>((x, y) => y % 2 == 0 ? x + 2D : x - 1D, 1, 3);

            //Assert
            Assert.IsInstanceOfType(fl1, typeof(double));
            Assert.AreEqual(fl1, 10D);

            Assert.IsInstanceOfType(fl2, typeof(double));
            Assert.AreEqual(fl2, 4D);

            Assert.IsInstanceOfType(fl3, typeof(double));
            Assert.AreEqual(fl3, 6D);
        }
        [TestMethod]
        public void FoldRightTest()
        {
            //Arrange
            var ap1 = new GeometricProgression(new double?[] { 4, 8 }, 5);

            //Action
            var fl1 = ap1.FoldRight<double>((x, y) => y % 2 == 0 && x == 0 ? y : x);
            var fl2 = ap1.FoldRight<double>((x, y) => y % 2 == 0 && x == 0 ? y : x, 3);
            var fl3 = ap1.FoldRight<double>((x, y) => y % 2 == 0 && x == 0 ? y : x, 3, 1);

            //Assert
            Assert.IsInstanceOfType(fl1, typeof(double));
            Assert.AreEqual(fl1, 64D);

            Assert.IsInstanceOfType(fl2, typeof(double));
            Assert.AreEqual(fl2, 32D);

            Assert.IsInstanceOfType(fl3, typeof(double));
            Assert.AreEqual(fl3, 32D);
        }
    }
}
