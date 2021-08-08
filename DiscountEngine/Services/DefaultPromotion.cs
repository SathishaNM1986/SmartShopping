using DiscountEngine.Interfaces;
using DiscountEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountEngine.Services
{
    public class DefaultPromotion : IPromotionEngine
    {
        public decimal GetDiscountPrice(CartOrder order, Promotion promotion)
        {
            return 0;
        }
    }
}
