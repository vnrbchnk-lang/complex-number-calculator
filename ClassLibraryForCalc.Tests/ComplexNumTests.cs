using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComplexCalculatorContracts;

namespace ClassLibraryForCalc.Tests
{
    [TestClass]
    public class ComplexNumTests
    {
        [TestMethod]
        public void Test01_CreateComplexNumber()
        {
            ComplexNum z = new ComplexNum(3, 4);
            Assert.AreEqual(3, z.RPart);
            Assert.AreEqual(4, z.ImPart);
        }

        [TestMethod]
        public void Test02_AddTwoNumbers()
        {
            ComplexNum a = new ComplexNum(2, 3);
            ComplexNum b = new ComplexNum(1, 4);
            IComplexNumber r = a.Plus(b);
            Assert.AreEqual(3, r.RPart);
            Assert.AreEqual(7, r.ImPart);
        }

        [TestMethod]
        public void Test03_AddZero()
        {
            ComplexNum a = new ComplexNum(5, 2);
            ComplexNum b = new ComplexNum(0, 0);
            IComplexNumber r = a.Plus(b);
            Assert.AreEqual(5, r.RPart);
            Assert.AreEqual(2, r.ImPart);
        }

        [TestMethod]
        public void Test04_SubtractTwoNumbers()
        {
            ComplexNum a = new ComplexNum(5, 7);
            ComplexNum b = new ComplexNum(2, 3);
            IComplexNumber r = a.Minus(b);
            Assert.AreEqual(3, r.RPart);
            Assert.AreEqual(4, r.ImPart);
        }

        [TestMethod]
        public void Test05_SubtractEqual()
        {
            ComplexNum a = new ComplexNum(3, 5);
            ComplexNum b = new ComplexNum(3, 5);
            IComplexNumber r = a.Minus(b);
            Assert.AreEqual(0, r.RPart);
            Assert.AreEqual(0, r.ImPart);
        }

        [TestMethod]
        public void Test06_MultiplyTwoNumbers()
        {
            ComplexNum a = new ComplexNum(2, 3);
            ComplexNum b = new ComplexNum(1, 4);
            IComplexNumber r = a.Mnoj(b);
            Assert.AreEqual(-10, r.RPart);
            Assert.AreEqual(11, r.ImPart);
        }

        [TestMethod]
        public void Test07_MultiplyByZero()
        {
            ComplexNum a = new ComplexNum(7, 9);
            ComplexNum b = new ComplexNum(0, 0);
            IComplexNumber r = a.Mnoj(b);
            Assert.AreEqual(0, r.RPart);
            Assert.AreEqual(0, r.ImPart);
        }

        [TestMethod]
        public void Test08_DivideTwoNumbers()
        {
            ComplexNum a = new ComplexNum(4, 2);
            ComplexNum b = new ComplexNum(1, 1);
            IComplexNumber r = a.Delen(b);
            Assert.AreEqual(3, r.RPart);
            Assert.AreEqual(-1, r.ImPart);
        }

        [TestMethod]
        public void Test09_DivideByZero()
        {
            ComplexNum a = new ComplexNum(5, 3);
            ComplexNum b = new ComplexNum(0, 0);
            Assert.ThrowsException<DivideByZeroException>(() => a.Delen(b));
        }

        [TestMethod]
        public void Test10_ComputeModulus()
        {
            ComplexNum z = new ComplexNum(3, 4);
            Assert.AreEqual(5, z.Modul);
        }

        [TestMethod]
        public void Test11_ZeroModulus()
        {
            ComplexNum z = new ComplexNum(0, 0);
            Assert.AreEqual(0, z.Modul);
        }

        [TestMethod]
        public void Test12_EqualNumbers()
        {
            ComplexNum a = new ComplexNum(2, 3);
            ComplexNum b = new ComplexNum(2, 3);
            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void Test13_NotEqualNumbers()
        {
            ComplexNum a = new ComplexNum(2, 3);
            ComplexNum b = new ComplexNum(5, 3);
            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void Test14_SmallerByModulus()
        {
            ComplexNum a = new ComplexNum(1, 1);
            ComplexNum b = new ComplexNum(3, 4);
            Assert.IsTrue(a.Smaller(b));
        }

        [TestMethod]
        public void Test15_BiggerByModulus()
        {
            ComplexNum a = new ComplexNum(6, 8);
            ComplexNum b = new ComplexNum(3, 4);
            Assert.IsTrue(a.Bigger(b));
        }

        [TestMethod]
        public void Test16_EqualModulus()
        {
            ComplexNum a = new ComplexNum(3, 4);
            ComplexNum b = new ComplexNum(-4, -3);
            Assert.IsTrue(a.SmallerOrEqual(b));
        }

        [TestMethod]
        public void Test19_FractionalNumbers()
        {
            ComplexNum a = new ComplexNum(2.5, -1.75);
            ComplexNum b = new ComplexNum(1.5, 0.25);
            IComplexNumber r = a.Plus(b);
            Assert.AreEqual(4.0, r.RPart);
            Assert.AreEqual(-1.5, r.ImPart);
        }
    }
}
