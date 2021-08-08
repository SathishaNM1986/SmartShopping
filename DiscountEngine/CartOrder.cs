using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountEngine
{
    public class CartOrder
    {
        public int OrderId { get; set; }
        public List<string> Products { get; set; }

        public CartOrder(int orderId, List<string> products)
        {
            OrderId = orderId;
            Products = products;
        }
       
    }
}
