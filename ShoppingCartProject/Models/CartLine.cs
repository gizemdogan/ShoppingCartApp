using ShoppingCartProject.Interfaces;

namespace ShoppingCartProject.Models
{
    public class CartLine : ICartLine
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
    }
}