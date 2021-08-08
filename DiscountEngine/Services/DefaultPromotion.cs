using DiscountEngine.Interfaces;
using DiscountEngine.Models;

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
