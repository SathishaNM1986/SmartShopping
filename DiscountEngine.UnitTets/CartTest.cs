using DiscountEngine.Models;
using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            Assert.AreEqual(100, orderBillDeatails.First().FinalPrice);
        }

        [TestMethod]
        public void GetOrderBillDetailsFinalPriceSecenario2Test()
        {
            // Assign
            List<CartOrder> orders = new List<CartOrder>();
            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'),new Product('A'),new Product('A'),new Product('A'),new Product('A'),
                new Product('B'),new Product('B'),new Product('B'),new Product('B'),new Product('B'),
                new Product('C')
            });
            Cart cart = new Cart(_promotions);
            cart.AddOrders(new CartOrder[] { order });

            // Act
            var orderBillDeatails = cart.GetOrderBillDetails();

            //Assert
            Assert.AreEqual(370, orderBillDeatails.First().FinalPrice);
        }

        [TestMethod]
        public void GetOrderBillDetailsFinalPriceSecenario3Test()
        {
            // Assign
            List<CartOrder> orders = new List<CartOrder>();
            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'),new Product('A'),new Product('A'),
                new Product('B'),new Product('B'),new Product('B'),new Product('B'),new Product('B'),
                new Product('C'),
                new Product('D')
            });
            Cart cart = new Cart(_promotions);
            cart.AddOrders(new CartOrder[] { order });

            // Act
            var orderBillDeatails = cart.GetOrderBillDetails();

            //Assert
            Assert.AreEqual(280, orderBillDeatails.First().FinalPrice);
        }

        [TestMethod]
        public void GetOrderBillDetailsFinalPriceSecenario4Test()
        {
            // Assign
            List<CartOrder> orders = new List<CartOrder>();
            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'), new Product('A'),  //100
                new Product('B'), new Product('B'), // 45
                new Product('C'), new Product('D'), }); ; //30
            Cart cart = new Cart(_promotions);
            cart.AddOrders(new CartOrder[] { order });

            // Act
            var orderBillDeatails = cart.GetOrderBillDetails();

            //Assert
            Assert.AreEqual(175, orderBillDeatails.First().FinalPrice);
        }

    }
}

