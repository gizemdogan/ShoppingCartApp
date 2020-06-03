using ShoppingCartProject.Interfaces;

namespace ShoppingCartProject.Models
{
    public class Product : IProduct
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public ICategory Category { get; set; }

        public Product()
        {
            Category = new Category();
        }

        public Product(string title, double price, ICategory category)
        {
            this.Title = title;
            this.Price = price;
            this.Category = category;
        }

    }
}