using DiscountEngine.Models;
using System;
using System.Collections.Generic;

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

        public double GetOrderBillDetails()
        {
            Cart cart = new Cart(new List<Promotion>());
            return 100;

        }
    }
}
