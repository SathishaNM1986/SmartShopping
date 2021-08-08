using DiscountEngine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.UnitTets.Services
{
    [TestClass]
    public class ProductPriceServicesTest
    {
        [TestMethod]
        public void ProductPricesInfoSetAndGetTest()
        {
            ProductPriceServices.ProductPricesInfo = PromoEngineTestHelper.ProductPricesInfo;
            Assert.IsNotNull(ProductPriceServices.ProductPricesInfo);

        }
    }
}
