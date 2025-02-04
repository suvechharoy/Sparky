using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup() // to globally initialize objects and use in test methods. This is the Arrange phase.
        {
            customer = new Customer();
        }
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            customer.GreetAndCombineNames("Suvechha", "Roy");

            //Assert
            Assert.Multiple(()=>{
                Assert.AreEqual(customer.GreetMessage, "Hello, Suvechha Roy!");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Suvechha Roy!"));
                Assert.That(customer.GreetMessage, Does.Contain("suvechha roy").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Roy!"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }
        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange

            //Act - do no invoke the method so that it returns null

            //Assert
            Assert.IsNull(customer.GreetMessage);
        }
        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int res = customer.Discount;
            Assert.That(res, Is.InRange(10, 25));
        }
        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("Suvechha", "");
            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }
        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(()=>customer.GreetAndCombineNames("","Roy"));//throwing exception
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            Assert.That(()=> customer.GreetAndCombineNames("", "Roy"),
            Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));//this combines both the above steps in a single assert.that method

            //exceptions without message
            Assert.Throws<ArgumentException>(()=>customer.GreetAndCombineNames("","Roy"));//throwing exception
            
            Assert.That(()=> customer.GreetAndCombineNames("", "Roy"),
            Throws.ArgumentException);//this combines both the above steps in a single assert.that method
        
        }
        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal=10;
            var res = customer.GetCustomerDetails();
            Assert.That(res, Is.TypeOf<BasicCustomer>());
        }
          [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPremiumCustomer()
        {
            customer.OrderTotal=110;
            var res = customer.GetCustomerDetails();
            Assert.That(res, Is.TypeOf<PremiumCustomer>());
        }
    }
}