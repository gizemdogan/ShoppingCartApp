using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Utility;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Kupon
    /// </summary>
    public class Coupon : ICoupon
    {
        /// <summary>
        /// Kullanım için minimum sepet tutarı
        /// </summary>
        public double MinPurchase { get; set; }

        /// <summary>
        /// Uygulanacak indirim oranı/miktarı
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// İndirim tipi
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minPurchase"></param>
        /// <param name="rate"></param>
        /// <param name="discountType"></param>
        public Coupon(double minPurchase, double rate, DiscountType discountType)
        {
            this.MinPurchase = minPurchase;
            this.Rate = rate;
            this.DiscountType = DiscountType;
        }
    }
}