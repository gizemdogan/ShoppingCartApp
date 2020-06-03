using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Utility;

namespace ShoppingCartProject.Models
{
    public class Coupon : ICoupon
    {
        public double MinPurchase { get; set; }
        public double Rate { get; set; }
        public DiscountType DiscountType { get; set; }

        public Coupon(double minPurchase, double rate, DiscountType discountType)
        {
            this.MinPurchase = minPurchase;
            this.Rate = rate;
            this.DiscountType = DiscountType;
        }

    }
}