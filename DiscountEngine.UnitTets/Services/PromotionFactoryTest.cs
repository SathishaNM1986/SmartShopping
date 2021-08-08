using DiscountEngine.Enums;
using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountEngine.UnitTets.Services
{
    [TestClass]
    public class PromotionFactoryTest
    {
        private PromotionFactory _promotionFactory;

        [TestMethod]
        public void GetPromotionEngineForDefaultTest()
        {
            // Assign
            _promotionFactory = new PromotionFactory(PromotionType.Discount);

            // Act
            var promotionEngine = _promotionFactory.GetPromotionEngine();

            //Assert
            Assert.IsInstanceOfType(promotionEngine, typeof(DefaultPromotion));
        }
    }
}
