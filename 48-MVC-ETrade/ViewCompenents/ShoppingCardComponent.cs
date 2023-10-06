using _48_MVC_ETrade.Models.Entities;
using _48_MVC_ETrade.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace _48_MVC_ETrade.ViewCompenents
{
    public class ShoppingCardComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartItems = new List<Product>() 
            { 
                new Product
                {
                    CategoryId = 1,
                    Description="kahve",
                    Name="Türk kayfesi",
                    Price=50,
                    Stock=50
                },
                 new Product
                {
                    CategoryId = 1,
                    Description="kahve",
                    Name="Türk kayfesi",
                    Price=50,
                    Stock=50
                }
            };

            var model = new ShoppingCardVM
            {
                Products = cartItems,
                Price = Calculate(cartItems)
            };

            return View(model);
        }
        private double Calculate (List<Product> cartItems)
        {
            double totalPrice = 0;
            foreach (var product in cartItems)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
