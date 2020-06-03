using ShoppingCartProject.Models;
using ShoppingCartProject.Utility;

namespace ShoppingCartProject.Interfaces
{
    public interface ICampaign
    {
         double Rate { get; set; }
         int ProductQuantity { get; set; }
         ICategory Category { get; set; }
         DiscountType DiscountType { get; set; }
    }
}
