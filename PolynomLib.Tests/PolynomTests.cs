using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using PolynomLib;
using NUnit.Framework;
using System.Threading;
using System.Globalization;

namespace PolynomLib.Tests
{
    [TestFixture]
    public class PolynomTests
    {

        [TestCase(new double[3] { 1, 15, -3 }, Result = "1+15x-3x^2")]
        [TestCase(new double[4] { 1.14, -2, 3, 13.4 }, Result = "1.14-2x+3x^2+13.4x^3")]
        public string ToStringTest(double[] pol)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Polynom polynom = new Polynom(pol);
            return polynom.ToString();
        }
        [TestCase(new double[] { 1, 15, -3 }, new double[] { 1, 15, -3 ,5}, Result = "2+30x-6x^2+5x^3")]
        [TestCase(new double[] { 1.14, 13.4 }, new double[] {-2, 3, 13.4 }, Result = "-0.86+16.4x+13.4x^2")]
        public string PlusOperatorTest(double[] a,double[] b)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Polynom x = new Polynom(a);
            Polynom y = new Polynom(b);
            return (x + y).ToString();
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionTest()
        {
            
            Polynom b = new Polynom(null);
        }
        [TestCase(new double[] { 1, 15, -3 }, new double[] { 1, 15, -3,5}, Result = "-5x^3")]
        [TestCase(new double[] { 1.14, 13.4,-156,19.3}, new double[] { -2, 3, 13.4 }, Result = "3.14+10.4x-169.4x^2+19.3x^3")]
        public string MinusOperatorTest(double[] a, double[] b)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Polynom x = new Polynom(a);
            Polynom y = new Polynom(b);
            return (x - y).ToString();
        }
        [Test]
        public void TrueEqualsTest()
        {
            Polynom p = new Polynom(1, 2, 3);
            Polynom a = p;
            bool x = a.Equals(p);
            Assert.AreEqual(true, x);
        }
        [Test]
        public void TrueEqualsTest2()
        {
            Polynom p = new Polynom(1, 2, 3);
            Polynom a = new Polynom(1, 2, 3);
            bool x = a.Equals(p);
            Assert.AreEqual(true, x);
        }
        [TestCase(new double[] { 1, 15, -3 }, new double[] { 1, 15, -2}, Result = false)]
        [TestCase(new double[] { 1.14, 13.4, -156, 19.3 }, new double[] { -2, 3, 13.4 }, Result = false)]
        public bool FalseEqualsTest(double[] x,double[] y)
        {
            Polynom p = new Polynom(x);
            Polynom a = new Polynom(y);
            return a.Equals(p);
        }
        [TestCase(new double[] { 1, 15, -2 }, new double[] { 1, 15, -2 }, Result = true)]
        [TestCase(new double[] { 1.14, 13.4, -156, 19.3 }, new double[] { -2, 3, 13.4 }, Result = false)]
        [TestCase(new double[] { 1.14, 13.4, -156}, new double[] { -2, 3, 13.4 }, Result = false)]
        public bool GetHashCodeTest(double[] x, double[] y)
        {
            Polynom p = new Polynom(x);
            Polynom a = new Polynom(y);
            return (a.GetHashCode()).Equals(p.GetHashCode());
        }
        [TestCase(new double[] { 1, 15, -3 }, new double[] { 1, 15, -3, 5 }, Result = "1+30x+219x^2-85x^3+84x^4-15x^5")]
        [TestCase(new double[] { 1.14, 13.4, -156, 19.3 }, new double[] { -2, 3, 13.4 }, Result = "-2.28-23.38x+367.476x^2-327.04x^3-2032.5x^4+258.62x^5")]
        [TestCase(new double[] { 1, 15, -3 }, new double[] { 1, 0, -3, 5 }, Result = "1+15x-6x^2-40x^3+84x^4-15x^5")]
        public string MultiplyOperatorTest(double[] a,double[] b)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Polynom x = new Polynom(a);
            Polynom y = new Polynom(b);
            return (x * y).ToString();
        }
    }
}



