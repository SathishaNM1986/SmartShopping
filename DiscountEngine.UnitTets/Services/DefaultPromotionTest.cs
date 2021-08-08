using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.UnitTets.Services
{
    [TestClass]
    public class DefaultPromotionTest
    {
        private DefaultPromotion _defaultPromotion;

        [TestMethod]
        public void GetDiscountPriceTest()
        {
            // Assign
            _defaultPromotion = new DefaultPromotion();

            // Act
            var acutalDiscountPrice = _defaultPromotion.GetDiscountPrice(null, null);

            //Assert
            Assert.AreEqual(0, acutalDiscountPrice);
        }
    }
}
