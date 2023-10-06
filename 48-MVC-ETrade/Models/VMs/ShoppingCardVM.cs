using _48_MVC_ETrade.Models.Entities;

namespace _48_MVC_ETrade.Models.VMs
{
    public class ShoppingCardVM
    {
        public List<Product> Products { get; set; } //Sepetin içindeki ürünler
        public double Price { get; set; } //Ürün Fiyat
    }
}
