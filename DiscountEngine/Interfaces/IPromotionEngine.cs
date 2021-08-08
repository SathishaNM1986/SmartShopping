using DiscountEngine.Models;

namespace DiscountEngine.Interfaces
{
    public interface IPromotionEngine
    {
        decimal GetDiscountPrice(CartOrder order, Promotion promotion);
    }
}
