using Moq;
using Xunit;

namespace Sparky
{    public class BankAccountXUnitTests
    {
        private BankAccount account;

        [Fact]
        public void BankDeposit_Add100_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x=>x.Message(""));

            BankAccount bankAccount = new BankAccount(logMock.Object);
            var res = bankAccount.Deposit(100);
            Assert.True(res);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x=>x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x=>x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var res = bankAccount.Withdraw(withdraw);
            Assert.True(res);
        }

        [Theory]
        [InlineData(200, 300)]
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
            Assert.False(res);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x=>x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str)=>str.ToLower());
            
            Assert.Equal(desiredOutput, logMock.Object.MessageWithReturnStr("heLLo"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x=>x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.True(logMock.Object.LogWithOutputResult("Suvechha", out result));
            Assert.Equal(desiredOutput, result);
        }

        [Fact]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new Customer();
            Customer inactiveCustomer = new Customer();

            logMock.Setup(x=>x.LogWithRefObject(ref customer)).Returns(true);

            Assert.True(logMock.Object.LogWithRefObject(ref customer));
        }

        [Fact]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(x=>x.LogSeverity).Returns(10);
            logMock.Setup(x=>x.LogType).Returns("error");

            Assert.Equal(10, logMock.Object.LogSeverity);
            Assert.Equal("error", logMock.Object.LogType);

            //callbacks
            string tempLog = "Hello, ";
            logMock.Setup(x=>x.LogToDb(It.IsAny<string>()))
            .Returns(true).Callback((string str) => tempLog+=str);
            logMock.Object.LogToDb("Suvechha");
            Assert.Equal("Hello, Suvechha", tempLog);

            //callbacks
            int c = 5;
            logMock.Setup(x=>x.LogToDb(It.IsAny<string>()))
            .Returns(true).Callback(() => c++);
            logMock.Object.LogToDb("Suvechha");
            logMock.Object.LogToDb("Suvechha");//calling method twice, will increase counter by 2
            Assert.Equal(7, c);
        }

        [Fact]
        public void BankLogDummy_VerifyDemo()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount account = new BankAccount(logMock.Object);
            account.Deposit(100);
            Assert.Equal(100, account.GetBalance());

            //verify if the method was called
            logMock.Verify(x=>x.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(x=>x.Message("Test Invoked"), Times.AtLeastOnce);
            logMock.VerifySet(x=>x.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(x=>x.LogSeverity, Times.Once);
        }
    }
}