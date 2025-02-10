using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        public CustomerXUnitTests()// to globally initialize objects and use in test methods. This is the Arrange phase.
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            customer.GreetAndCombineNames("Suvechha", "Roy");

            //Assert
            Assert.Equal("Hello, Suvechha Roy!", customer.GreetMessage);
            Assert.Contains("suvechha roy", customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Roy!", customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange

            //Act - do no invoke the method so that it returns null

            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int res = customer.Discount;
            Assert.InRange(res, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("Suvechha", "");
            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(()=>customer.GreetAndCombineNames("","Roy"));//throwing exception
            Assert.Equal("Empty First Name", exceptionDetails.Message);
            
            //exceptions without message
            Assert.Throws<ArgumentException>(()=>customer.GreetAndCombineNames("","Roy"));//throwing exception
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal=10;
            var res = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(res);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPremiumCustomer()
        {
            customer.OrderTotal=110;
            var res = customer.GetCustomerDetails();
            Assert.IsType<PremiumCustomer>(res);
        }
    }
}