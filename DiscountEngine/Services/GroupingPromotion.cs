using DiscountEngine.Interfaces;
using DiscountEngine.Models;
using System;
using System.Linq;

namespace DiscountEngine.Services
{
    public class GroupingPromotion : IPromotionEngine
    {
        public decimal GetDiscountPrice(CartOrder order, Promotion promotion)
        {
            decimal discountAmount = 0;
            try
            {
                // Group by product/skuid 
                var grpProducts = order.Products.GroupBy(x => x.SkuId);
                // promo eligible
                var promoeligibleItems = grpProducts.Where(grp => promotion.ProductInfo
                    .Any(promoProduct => grp.Key == promoProduct.Key && grp.Count() >= promoProduct.Value));
                if (promoeligibleItems.Any())
                {
                    var promoEligibleItemsCount = promoeligibleItems.Select(grp => grp.Count()).Sum();

                    // read the total count of promoted products from promotion
                    int promoPreDefinedQuantitySum = promotion.ProductInfo.Sum(prodinfo => prodinfo.Value);

                    var result = promoeligibleItems.ToDictionary(group => group.Key, group => group.ToList()).Values;
                    decimal totalUnitPrice = 0;
                    foreach (var item in result)
                    {
                        foreach (var product in item.Take(promoPreDefinedQuantitySum))
                        {
                            totalUnitPrice += product.Price;
                        }
                    }
                    while (promoPreDefinedQuantitySum > 0 && promoEligibleItemsCount >= promoPreDefinedQuantitySum)
                    {
                        discountAmount += (totalUnitPrice - promotion.PromoPrice);
                        promoEligibleItemsCount -= promoPreDefinedQuantitySum;
                    }
                }
            }
            catch (Exception)
            {
                // Error handling and logging
                // use some logging mechanism like log4 net ...etc 
            }
            return discountAmount;
        }
    }
}

