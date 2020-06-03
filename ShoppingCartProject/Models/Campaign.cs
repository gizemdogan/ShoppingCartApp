using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Utility;

namespace ShoppingCartProject.Models
{
    public class Campaign : ICampaign
    {
        public double Rate { get; set; }
        public int ProductQuantity { get; set; }
        public ICategory Category { get; set; }
        public DiscountType DiscountType { get; set; }


        public Campaign()
        {
            Category = new Category();
        }

        public Campaign(ICategory category, double rate, int productQuantity, DiscountType discountType)
        {
            this.Category = category;
            this.Rate = rate;
            this.ProductQuantity = productQuantity;
            this.DiscountType = discountType;
        }
    }
}