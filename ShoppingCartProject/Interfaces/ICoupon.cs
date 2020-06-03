using ShoppingCartProject.Models;
using ShoppingCartProject.Utility;

namespace ShoppingCartProject.Interfaces
{
    public interface ICoupon
    {
         double MinPurchase { get; set; }
         double Rate { get; set; }
         DiscountType DiscountType { get; set; }
    }
}
