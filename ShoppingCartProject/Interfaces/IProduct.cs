using ShoppingCartProject.Models;

namespace ShoppingCartProject.Interfaces
{
    public interface IProduct
    {
         string Title { get; set; }
         double Price { get; set; }
         ICategory Category { get; set; }
    }
}
