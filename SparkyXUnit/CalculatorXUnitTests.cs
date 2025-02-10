
using Sparky;
using Xunit;

namespace Sparky 
{
    public class CalculatorXUnitTests
    {
        [Fact] 
        public void Add_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator cal = new();

            //Act
            int res = cal.Add(10, 30);

            //Assert
            Assert.Equal(40, res);
        }

        [Fact]
        public void IsOdd_InputEvenNum_ReturnFalse()
        {
            Calculator cal = new Calculator();
            bool res = cal.IsOdd(10);
            Assert.False(res);
        }

        [Theory]
        [InlineData(13)]
        [InlineData(9)]
        public void IsOdd_InputOddNum_ReturnTrue(int a)
        {
            Calculator cal = new Calculator();
            bool res = cal.IsOdd(a);
            Assert.True(res);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator cal = new Calculator();
            bool res = cal.IsOdd(a);
            Assert.Equal(expectedResult, res);
        }

        [Theory] 
        [InlineData(2.4,3.4)] //5.8
        // [InlineData(2.7,3.7)] //6.4
        // [InlineData(2.9,3.9)] //6.8
        public void AddDoubles_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator cal = new Calculator();

            //Act
            double res = cal.AddDoubles(a, b);

            //Assert
            Assert.Equal(5.8, res, 1);
        }

        [Fact]
        public void GetOddRange_InputMinAndMax_ReturnsValidOddRange()
        {
            Calculator cal = new Calculator();
            List<int> expected = new List<int>() {5,7,9};

            List<int> result = cal.GetOddRange(4,10);

            Assert.Equal(expected, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u=>u), result);
            //Assert.That(result, Is.Unique);
        }
    }
}