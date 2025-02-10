using Xunit;

namespace Sparky
{
    public class FiboXUnitTests
    {
        [Fact]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            Fibo fibo = new Fibo();
            fibo.Range = 1;
            List<int> expected = new List<int>() {0};
            List<int> res = fibo.GetFiboSeries();
            Assert.NotEmpty(res);
            Assert.Equal(expected.OrderBy(x=>x), res);
            Assert.True(res.SequenceEqual(expected));
            Assert.Contains(0, res);
        }

        [Fact]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            Fibo fibo = new();
            fibo.Range=6;
            List<int> expected = new List<int>() {0,1,1,2,3,5};
            List<int> result = fibo.GetFiboSeries();
            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expected, result);
        }
    }
}