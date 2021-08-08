using DiscountEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountEngine.UnitTets
{
    public static class PromoEngineTestHelper
    {

        public static List<Product> ProductPricesInfo = new List<Product>
            {
                new Product {SkuId ='A',Price =50 },
                new Product {SkuId ='B',Price =30 },
                new Product { SkuId = 'C', Price = 20 },
                new Product { SkuId = 'D', Price = 15 },
            };

        public static List<Promotion> Promotions = new List<Promotion>()
                {
                    new Promotion(1, 'A',3, 130),
                    new Promotion(2, 'B', 2, 45),
                    new Promotion(3,new Dictionary<char, int> {{ 'C', 1 },{ 'D', 1 } }, 30)
                };
    }
}
