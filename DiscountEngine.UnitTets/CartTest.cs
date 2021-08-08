using DiscountEngine.Models;
using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DiscountEngine.UnitTets
{
    [TestClass]
    public class CartTest
    {
        private List<Promotion> _promotions;

        [TestInitialize]
        public void Initialize()
        {
            // Need to be configurable on real scenario -DB,through UI,XML/json file, etc 
            ProductPriceServices.ProductPricesInfo = PromoEngineTestHelper.ProductPricesInfo;
            _promotions = PromoEngineTestHelper.Promotions;

        }

        [TestCleanup]
        public void TestClean()
        {
            ProductPriceServices.ProductPricesInfo = null;
            _promotions = null;

        }

        [TestMethod]
        public void GetOrderBillDetailsFinalPriceSecenario1Test()
        {
            // Assign
            List<CartOrder> orders = new List<CartOrder>();
            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'), new Product('B'), new Product('C')
            });

            Cart cart = new Cart(_promotions);
            cart.AddOrders(new CartOrder[] { order });

            // Act
            var orderBillDeatails = cart.GetOrderBillDetails();

            //Assert
            Assert.AreEqual(100, orderBillDeatails);
        }
    }
}

