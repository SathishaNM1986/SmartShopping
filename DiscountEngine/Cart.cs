using System;
using System.Collections.Generic;

namespace DiscountEngine
{
    public class Cart
    {

        public void AddOrders()
        {
            
        }

        public double GetOrderBillDetails()
        {
            CartOrder order = new CartOrder(1, new List<string> { "A", "B" });
            return 100;

        }
    }
}
