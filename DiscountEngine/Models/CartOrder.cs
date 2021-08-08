using DiscountEngine.Models;
using System;
using System.Collections.Generic;
namespace DiscountEngine
{
    public class CartOrder
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }

        public CartOrder(int orderId, List<Product> products)
        {
            OrderId = orderId;
            Products = products;
        }

    }
}
