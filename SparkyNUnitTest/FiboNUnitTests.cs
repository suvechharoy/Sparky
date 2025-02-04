using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Sparky
{
    [TestFixture]
    public class FiboNUnitTests
    {
        [Test]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            Fibo fibo = new Fibo();
            fibo.Range = 1;
            List<int> list = new List<int>() {0};
            List<int> res = fibo.GetFiboSeries();
            Assert.That(res, Is.Not.Empty);
            Assert.That(res, Is.Ordered);
            Assert.That(res, Is.EquivalentTo(list));
            Assert.That(res, Has.Member(0));
        }
        [Test]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            Fibo fibo = new();
            fibo.Range=6;
            List<int> expected = new List<int>() {0,1,1,2,3,5};
            List<int> result = fibo.GetFiboSeries();
            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}