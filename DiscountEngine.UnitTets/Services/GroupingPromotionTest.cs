using DiscountEngine.Models;
using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DiscountEngine.UnitTets.Services
{
    [TestClass]
    public class GroupingPromotionTest
    {
        private List<Promotion> _promotions;
        private GroupingPromotion _groupingPromotion;

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
            _groupingPromotion = null;

        }

        [TestMethod]
        [DataRow(0, 20)]
        [DataRow(1, 30)]
        [DataRow(2, 5)]
        public void GetDiscountPriceTest(int promotionNumber, double expectedDiscountPrice)
        {
            // Assign
            _groupingPromotion = new GroupingPromotion();
            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'),new Product('A'),new Product('A'),
                new Product('B'),new Product('B'),new Product('B'),new Product('B'),new Product('B'),
                new Product('C'),
                new Product('D')
            });

            // Act
            var acutalDiscountPrice = _groupingPromotion.GetDiscountPrice(order, _promotions[promotionNumber]);

            //Assert
            Assert.AreEqual(Convert.ToDecimal(expectedDiscountPrice), acutalDiscountPrice);
        }
    }
}