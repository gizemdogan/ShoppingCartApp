using ShoppingCartProject.Interfaces;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Ürün
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Ürün Adı
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Ürün Fiyatı
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///  Ürünün kategorisi
        /// </summary>
        public ICategory Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Product()
        {
            Category = new Category();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        public Product(string title, double price, ICategory category)
        {
            this.Title = title;
            this.Price = price;
            this.Category = category;
        }
    }
}