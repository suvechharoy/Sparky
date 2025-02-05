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
        // [Test]
        // public void BankDepositLogFaker_Add100_ReturnsTrue()
        // {
        //     BankAccount bankAccount = new BankAccount(new LogFaker());
        //     var res = bankAccount.Deposit(100);
        //     Assert.That(res, Is.True);
        //     Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        // }
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
        [Test]
        [TestCase(200, 100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x=>x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x=>x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var res = bankAccount.Withdraw(withdraw);
            Assert.That(res, Is.True);
        }
        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x=>x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x=>x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);
            logMock.Setup(x=>x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x<0))).Returns(false);
            //logMock.Setup(x=>x.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);//to check for a certain range. Parameters: range from i.e. MINVALUE, range to i.e. -1, range kind (includes both MINVALUE & -1)

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var res = bankAccount.Withdraw(withdraw);
            Assert.IsFalse(res);
        }
        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x=>x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str)=>str.ToLower());
            
            Assert.That(logMock.Object.MessageWithReturnStr("heLLo"), Is.EqualTo(desiredOutput));
        }
        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x=>x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Suvechha", out result));
            
            Assert.That(result, Is.EqualTo(desiredOutput));
        }
        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new Customer();
            Customer inactiveCustomer = new Customer();

            logMock.Setup(x=>x.LogWithRefObject(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObject(ref customer));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(x=>x.LogSeverity).Returns(10);
            logMock.Setup(x=>x.LogType).Returns("error");

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("error"));
        }
    }
}