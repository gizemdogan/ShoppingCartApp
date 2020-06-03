using ShoppingCartProject.Interfaces;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Sepet Ürün-Quantity bilgisi
    /// </summary>
    public class CartLine : ICartLine
    {
        /// <summary>
        /// Sepete eklenen ürün
        /// </summary>
        public IProduct Product { get; set; }

        /// <summary>
        /// Sepete eklenen ürün adedi
        /// </summary>
        public int Quantity { get; set; }
    }
}