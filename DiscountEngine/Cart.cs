using DiscountEngine.Enums;
using DiscountEngine.Models;
using DiscountEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountEngine
{
    public class Cart
    {
        private List<CartOrder> _orders = new List<CartOrder>();
        private List<Promotion> _promotions = new List<Promotion>();
        public Cart(List<Promotion> promotions)
        {
            _promotions = promotions;

        }

        public void AddOrders(CartOrder[] cartOrders)
        {
            this._orders.AddRange(cartOrders);
        }

        public List<OrderBill> GetOrderBillDetails(MaxPromotions maxPromotions = MaxPromotions.All)
        {
            List<OrderBill> orderBills = new List<OrderBill>();
            try
            {
                // Loop through each order to calcalute OriginalPrice,Discount price using cartprice service
                foreach (CartOrder order in _orders)
                {
                    var promoDiscountPrices = _promotions
                         .Select(promotion =>
                         new CartPriceService(
                             // Factory Pattren -Const-DI
                             new PromotionFactory(promotion.PromotionType)
                             .GetPromotionEngine()
                             )
                         .GetDiscountPrice(order, promotion))
                         .ToList();

                    // TODO : can be converted into design pattren
                    decimal promoDiscountPrice = 0;
                    bool promoEligible = false;
                    if (promoDiscountPrices.Any())
                    {
                        promoEligible = true;
                        if (maxPromotions == MaxPromotions.All)
                        {
                            promoDiscountPrice = promoDiscountPrices.Sum();
                        }
                        else if (maxPromotions == MaxPromotions.OneBest)
                        {
                            promoDiscountPrice = promoDiscountPrices.Max();
                        }
                    }

                    var originalSumPrice = order.Products.Sum(x => x.Price);
                    var finalPrice = originalSumPrice - promoDiscountPrice;
                    var promoApplied = finalPrice < originalSumPrice;
                    orderBills.Add(new OrderBill { OriginalPrice = originalSumPrice, DiscountPrice = promoDiscountPrice, FinalPrice = finalPrice, PromoEligible = promoEligible, PromoApplied = promoApplied });
                    // Log.Info($"OrderID: {order.Products} => Original price: {originalSumPrice.ToString("0.00")} | Discount: {promoDiscountPrice.ToString("0.00")} | Final price: {finalPrice.ToString("0.00")}");
                }
            }
            catch (Exception)
            {
                // Error handling and logging
                // use some logging mechanism like log4 net ...etc 
            }
            return orderBills;
        }
    }
}
