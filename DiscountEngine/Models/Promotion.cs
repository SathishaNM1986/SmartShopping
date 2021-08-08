using DiscountEngine.Enums;
using System.Collections.Generic;

namespace DiscountEngine.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public Dictionary<char, int> ProductInfo { get; set; }
        public decimal PromoPrice { get; set; }
        public PromotionType PromotionType { get; set; }

        public Promotion(int id, Dictionary<char, int> productInfo, decimal promoPrice, PromotionType promotionType = PromotionType.Grouping)
        {
            Id = id;
            ProductInfo = productInfo;
            PromoPrice = promoPrice;
            PromotionType = promotionType;
        }

        public Promotion(int id, char skuId, int quantity, decimal promoPrice, PromotionType promotionType = PromotionType.Grouping)
        {
            Id = id;
            ProductInfo = new Dictionary<char, int>
            {
                {skuId , quantity }
            };
            PromoPrice = promoPrice;
            PromotionType = promotionType;
        }
    }
}
