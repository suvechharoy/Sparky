using Moq;
using Xunit;

namespace Sparky
{
    public class ProductXUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWithDiscount()
        {
            Product product = new Product { Price = 50 };
            var result = product.GetPrice(new Customer() {IsPlatinum=true});
            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWithDiscount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(x=>x.IsPlatinum).Returns(true);
            Product product = new Product { Price = 50 };
            var result = product.GetPrice(customer.Object);
            Assert.Equal(40, result);
        }
    }
}