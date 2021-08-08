using DiscountEngine.Models;

namespace DiscountEngine.Interfaces
{
    public interface ICartPriceService
    {
        decimal GetDiscountPrice(CartOrder order, Promotion promotion);
    }
}
