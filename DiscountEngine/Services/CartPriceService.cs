using DiscountEngine.Interfaces;
using DiscountEngine.Models;

namespace DiscountEngine.Services
{
    public class CartPriceService : ICartPriceService
    {
        private IPromotionEngine _promotionEngine;

        public CartPriceService(IPromotionEngine promotionEngine)
        {
            _promotionEngine = promotionEngine;
        }

        public decimal GetDiscountPrice(CartOrder order, Promotion promotion)
        {
            return _promotionEngine.GetDiscountPrice(order, promotion);
        }

    }
}
