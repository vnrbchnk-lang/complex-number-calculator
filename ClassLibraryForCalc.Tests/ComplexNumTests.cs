using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComplexCalculatorContracts;

namespace ClassLibraryForCalc.Tests
{
    [TestClass]
    public class ComplexNumTests
    {
        [DataTestMethod]
        [DataRow(3.0, 4.0)]
        [DataRow(2.5, -1.75)]
        public void CreateComplexNumber(double re, double im)
        {
            ComplexNum z = new ComplexNum(re, im);
            Assert.AreEqual(re, z.RPart);
            Assert.AreEqual(im, z.ImPart);
        }

        [DataTestMethod]
        [DataRow(2.0, 3.0, 1.0, 4.0, 3.0, 7.0)]
        [DataRow(5.0, 2.0, 0.0, 0.0, 5.0, 2.0)]
        public void Plus(double re1, double im1, double re2, double im2,
                         double expRe, double expIm)
        {
            ComplexNum a = new ComplexNum(re1, im1);
            ComplexNum b = new ComplexNum(re2, im2);
            IComplexNumber r = a.Plus(b);
            Assert.AreEqual(expRe, r.RPart);
            Assert.AreEqual(expIm, r.ImPart);
        }

        [DataTestMethod]
        [DataRow(5.0, 7.0, 2.0, 3.0, 3.0, 4.0)]
        [DataRow(5.0, 2.0, 0.0, 0.0, 5.0, 2.0)]
        [DataRow(3.0, 5.0, 3.0, 5.0, 0.0, 0.0)]
        public void Minus(double re1, double im1, double re2, double im2,
                          double expRe, double expIm)
        {
            ComplexNum a = new ComplexNum(re1, im1);
            ComplexNum b = new ComplexNum(re2, im2);
            IComplexNumber r = a.Minus(b);
            Assert.AreEqual(expRe, r.RPart);
            Assert.AreEqual(expIm, r.ImPart);
        }

        [DataTestMethod]
        [DataRow(2.0, 3.0, 1.0, 4.0, -10.0, 11.0)]
        [DataRow(7.0, 9.0, 0.0, 0.0, 0.0, 0.0)]
        public void Mnoj(double re1, double im1, double re2, double im2,
                         double expRe, double expIm)
        {
            ComplexNum a = new ComplexNum(re1, im1);
            ComplexNum b = new ComplexNum(re2, im2);
            IComplexNumber r = a.Mnoj(b);
            Assert.AreEqual(expRe, r.RPart);
            Assert.AreEqual(expIm, r.ImPart);
        }

        [DataTestMethod]
        [DataRow(4.0, 2.0, 1.0, 1.0, 3.0, -1.0)]
        [DataRow(0.0, 0.0, 2.0, 3.0, 0.0, 0.0)]
        [DataRow(3.0, 5.0, 3.0, 5.0, 1.0, 0.0)]
        public void Delen(double re1, double im1, double re2, double im2,
                          double expRe, double expIm)
        {
            ComplexNum a = new ComplexNum(re1, im1);
            ComplexNum b = new ComplexNum(re2, im2);
            IComplexNumber r = a.Delen(b);
            Assert.AreEqual(expRe, r.RPart);
            Assert.AreEqual(expIm, r.ImPart);
        }

        [TestMethod]
        public void DivideByZero_Throws()
        {
            ComplexNum a = new ComplexNum(5, 3);
            ComplexNum b = new ComplexNum(0, 0);
            Assert.ThrowsException<DivideByZeroException>(() => a.Delen(b));
        }

        [DataTestMethod]
        [DataRow(2.0, 3.0, 2.0, 3.0, true)]
        [DataRow(2.0, 3.0, 5.0, 3.0, false)]
        public void Equality(double re1, double im1, double re2, double im2, bool expected)
        {
            ComplexNum a = new ComplexNum(re1, im1);
            ComplexNum b = new ComplexNum(re2, im2);
            Assert.AreEqual(expected, a.Equals(b));
        }

        [TestMethod]
        public void Smaller_ByModulus()
        {
            ComplexNum a = new ComplexNum(1, 1);
            ComplexNum b = new ComplexNum(3, 4);
            Assert.IsTrue(a.Smaller(b));
        }

        [TestMethod]
        public void Bigger_ByModulus()
        {
            ComplexNum a = new ComplexNum(6, 8);
            ComplexNum b = new ComplexNum(3, 4);
            Assert.IsTrue(a.Bigger(b));
        }

        [TestMethod]
        public void SmallerOrEqual_OnEqualModulus()
        {
            ComplexNum a = new ComplexNum(3, 4);
            ComplexNum b = new ComplexNum(-4, -3);
            Assert.IsTrue(a.SmallerOrEqual(b));
        }

        [TestMethod]
        public void BiggerOrEqual_OnEqualModulus()
        {
            ComplexNum a = new ComplexNum(3, 4);
            ComplexNum b = new ComplexNum(-4, -3);
            Assert.IsTrue(a.BiggerOrEqual(b));
        }
    }
}
