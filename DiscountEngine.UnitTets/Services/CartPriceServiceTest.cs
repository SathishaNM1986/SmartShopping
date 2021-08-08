using DiscountEngine.Enums;
using DiscountEngine.Interfaces;
using DiscountEngine.Models;
using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountEngine.UnitTets.Services
{
    [TestClass]
    public class CartPriceServiceTest
    {
        private List<Promotion> _promotions;
        private CartPriceService _cartPriceService;

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
            _cartPriceService = null;

        }

        [TestMethod]
        [DataRow(PromotionType.Grouping, 0, 20)]
        [DataRow(PromotionType.Grouping, 1, 30)]
        [DataRow(PromotionType.Grouping, 2, 5)]
        [DataRow(PromotionType.Discount, 0, 0)]
        public void GetDiscountPriceTest(PromotionType promotionType, int promotionNumber, double expectedDiscountPrice)
        {
            // Assign
            IPromotionEngine promotionEngine = new PromotionFactory(promotionType).GetPromotionEngine();
            _cartPriceService = new CartPriceService(promotionEngine);

            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'),new Product('A'),new Product('A'),
                new Product('B'),new Product('B'),new Product('B'),new Product('B'),new Product('B'),
                new Product('C'),
                new Product('D')
            });

            // Act
            var acutalDiscountPrice = _cartPriceService.GetDiscountPrice(order, _promotions[promotionNumber]);

            //Assert
            Assert.AreEqual(Convert.ToDecimal(expectedDiscountPrice), acutalDiscountPrice);
        }
    }
}