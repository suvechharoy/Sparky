using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWithDiscount()
        {
            Product product = new Product { Price = 50 };
            var result = product.GetPrice(new Customer() {IsPlatinum=true});
            Assert.That(result, Is.EqualTo(40));
        }
        [Test]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWithDiscount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(x=>x.IsPlatinum).Returns(true);
            Product product = new Product { Price = 50 };
            var result = product.GetPrice(customer.Object);
            Assert.That(result, Is.EqualTo(40));
        }
    }
}