using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void Add_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator cal = new();

            //Act
            int res = cal.Add(10, 30);

            //Assert
            Assert.AreEqual(40, res);
        }
    }
}