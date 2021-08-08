using DiscountEngine;
using DiscountEngine.Models;
using DiscountEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DiscountEngineApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionPriceController : ControllerBase
    {

        private readonly ILogger<PromotionPriceController> _logger;


        public PromotionPriceController(ILogger<PromotionPriceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<OrderBill> Get(List<Product> productPricesInfo, List<Promotion> promotions)
        {
           
            ProductPriceServices.ProductPricesInfo = productPricesInfo;
            List<CartOrder> orders = new List<CartOrder>();
            CartOrder order = new CartOrder(1, new List<Product>() {
                new Product('A'),new Product('A'),new Product('A'),new Product('A'),new Product('A'),
                new Product('B'),new Product('B'),new Product('B'),new Product('B'),new Product('B'),
                new Product('C')
            });
            Cart cart = new Cart(promotions);
            cart.AddOrders(new CartOrder[] { order });

           return cart.GetOrderBillDetails();

        }
    }
}
