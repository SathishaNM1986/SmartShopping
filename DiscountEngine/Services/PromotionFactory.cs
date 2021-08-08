using DiscountEngine.Enums;
using DiscountEngine.Interfaces;

namespace DiscountEngine.Services
{
    public class PromotionFactory
    {
        private readonly PromotionType _promotionType;
        public PromotionFactory(PromotionType PromotionType)
        {
            _promotionType = PromotionType;
        }
        public IPromotionEngine GetPromotionEngine()
        {
            IPromotionEngine promotionEngine = null;
            switch (_promotionType)
            {
                case PromotionType.Grouping:
                    promotionEngine = new GroupingPromotion();
                    break;
                default:
                    promotionEngine = new DefaultPromotion();
                    break;
            }
            return promotionEngine;
        }
    }
}
