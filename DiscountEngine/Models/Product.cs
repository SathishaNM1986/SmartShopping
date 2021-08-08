using DiscountEngine.Services;
using System.Linq;

namespace DiscountEngine.Models
{
    public class Product
    {
        public char SkuId { get; set; }
        public decimal Price { get; set; }
        public Product()
        {
        }

        public Product(char skuId)
        {
            SkuId = skuId;
            Price = ProductPriceServices.ProductPricesInfo.FirstOrDefault(x => x.SkuId == SkuId).Price;
        }
    }
}
