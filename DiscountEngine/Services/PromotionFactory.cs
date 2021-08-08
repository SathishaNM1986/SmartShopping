using DiscountEngine.Enums;
using DiscountEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            promotionEngine = new DefaultPromotion();
            return promotionEngine;

        }
    }
}
