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
            Cart cart = new Cart();
            cart.AddOrders();

            // Act
            var expectedFinalPrice = cart.GetOrderBillDetails(); ;

            //Assert
            Assert.AreEqual(100, expectedFinalPrice);
        }
    }
}

