using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Utility;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Kampanya 
    /// </summary>
    public class Campaign : ICampaign
    {
        /// <summary>
        /// Kampanya oranı/miktarı
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Kullanımı için gerekli olan minumum ürün sayısı
        /// </summary>
        public int ProductQuantity { get; set; }

        /// <summary>
        /// Uygulanacak kategori bilgisi
        /// </summary>
        public ICategory Category { get; set; }

        /// <summary>
        /// İndirim tipi
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Campaign()
        {
            Category = new Category();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="rate"></param>
        /// <param name="productQuantity"></param>
        /// <param name="discountType"></param>
        public Campaign(ICategory category, double rate, int productQuantity, DiscountType discountType)
        {
            this.Category = category;
            this.Rate = rate;
            this.ProductQuantity = productQuantity;
            this.DiscountType = discountType;
        }
    }
}