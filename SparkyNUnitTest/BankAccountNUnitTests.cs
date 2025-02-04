using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void BankDepositLogFaker_Add100_ReturnsTrue()
        {
            BankAccount bankAccount = new BankAccount(new LogFaker());
            var res = bankAccount.Deposit(100);
            Assert.That(res, Is.True);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
        [Test]
        public void BankDeposit_Add100_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x=>x.Message(""));

            BankAccount bankAccount = new BankAccount(logMock.Object);
            var res = bankAccount.Deposit(100);
            Assert.That(res, Is.True);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
    }
}