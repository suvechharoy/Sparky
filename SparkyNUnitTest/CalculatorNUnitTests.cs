using NUnit.Framework;
using Sparky;

namespace Sparky 
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test] 
        public void Add_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator cal = new();

            //Act
            int res = cal.Add(10, 30);

            //Assert
            Assert.AreEqual(40, res);
        }
        [Test]
        public void IsOdd_InputEvenNum_ReturnFalse()
        {
            Calculator cal = new Calculator();
            bool res = cal.IsOdd(10);
            Assert.IsFalse(res);
        }
        [Test]
        [TestCase(13)]
        [TestCase(9)]
        public void IsOdd_InputOddNum_ReturnTrue(int a)
        {
            Calculator cal = new Calculator();
            bool res = cal.IsOdd(a);
            Assert.IsTrue(res);
        }
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator cal = new Calculator();
            bool res = cal.IsOdd(a);
            return res;
        }
        [Test] 
        [TestCase(2.4,3.4)] //5.8
        [TestCase(2.7,3.7)] //6.4
        [TestCase(2.9,3.9)] //6.8
        public void AddDoubles_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator cal = new Calculator();

            //Act
            double res = cal.AddDoubles(a, b);

            //Assert
            Assert.AreEqual(5.8, res, 1);
        }
        [Test]
        public void GetOddRange_InputMinAndMax_ReturnsValidOddRange()
        {
            Calculator cal = new Calculator();
            List<int> expected = new List<int>() {5,7,9};

            List<int> result = cal.GetOddRange(4,10);

            Assert.That(result, Is.EquivalentTo(expected));
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}