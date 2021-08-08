using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.UnitTets
{
    [TestClass]
    public class CartTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void TestClean()
        {

        }

        [TestMethod]
        public void GetOrderBillDetailsFinalPriceSecenario1Test()
        {
            // Assign
            DiscountEngine discountEngine = new DiscountEngine();

            // Act
            var expectedFinalPrice = discountEngine.GetFinalPrice();

            //Assert
            Assert.AreEqual(100, expectedFinalPrice);
        }
    }
}

