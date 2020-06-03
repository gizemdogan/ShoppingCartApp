using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Sepet
    /// </summary>
    public partial class ShoppingCart : IShoppingCart
    {
        /// <summary>
        /// Sepet içindeki ürün ve adet bilgileri listesi
        /// </summary>
        public List<ICartLine> CartLines { get; set; }

        /// <summary>
        /// Sepetin güncel tutarı
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Kupon indirimi
        /// </summary>
        public double CouponDiscount { get; set; }

        /// <summary>
        /// Kampanya İndirim,
        /// </summary>
        public double CampaignDiscount { get; set; }

        /// <summary>
        /// Kargo ücreti
        /// </summary>
        public double DeliveryCost { get; set; }

        /// <summary>
        /// Sepetin indirimsiz baz ücreti
        /// </summary>
        public double OriginalCartPrice
        {
            get
            {
                return CartLines.Sum(x => x.Product.Price * x.Quantity);
            }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        public ShoppingCart()
        {
            CartLines = new List<ICartLine>();
        }

        /// <summary>
        /// Sepete ürün ve adet bilgisini ekleme
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(IProduct product, int quantity)
        {
            var cardLines = CartLines.Where(x => x.Product == product).ToList();

            if (cardLines != null && cardLines.Count() > 0)
            {
                cardLines.First().Quantity += quantity;
            }
            else
            {
                CartLines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });

            }

            this.TotalPrice = this.OriginalCartPrice;
        }

        /// <summary>
        /// Ürünün kategorileri ve üst kategorileri , kampanyanın kategorisne eşitse ve toplam adet kampanya kurallarını sağlıyosa indirim yapılabilir.
        /// </summary>
        /// <param name="campaigns"></param>
        public void ApplyDiscounts(params ICampaign[] campaigns)
        {
            double totalCampaignDiscount = 0;
            foreach (var campaign in campaigns)
            {
                if (CartLines.FindAll(x => x.Product.Category.GetParentCategories().Exists(a => a == campaign.Category)).Sum(y => y.Quantity) >= campaign.ProductQuantity)
                {
                    double discount = calculateDiscount(TotalPrice, campaign.Rate, campaign.DiscountType);
                    TotalPrice -= discount;
                    totalCampaignDiscount += discount;
                }
            }

            CampaignDiscount = totalCampaignDiscount;
        }

        /// <summary>
        /// Kampanya indirimi sonraki tutar; minumum sepet tutarından büyük ve eşitse kupon uygulanır.
        /// </summary>
        /// <param name="coupon"></param>
        public void ApplyCoupon(ICoupon coupon)
        {
            if (TotalPrice >= coupon.MinPurchase)
            {
                double discount = calculateDiscount(TotalPrice, coupon.Rate, coupon.DiscountType);
                TotalPrice -= discount;
                CouponDiscount = discount;
            }
        }

        /// <summary>
        /// Tutar , indirim oranı/tutarı ve indirim tipine göre indirim tutarını hesaplaması yapılır.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="rate"></param>
        /// <param name="discountType"></param>
        /// <returns></returns>
        private double calculateDiscount(double price, double rate, DiscountType discountType)
        {
            if (discountType == DiscountType.Rate)
            {
                return price * (rate / 100);
            }
            else
            {
                return rate;
            }
        }

        /// <summary>
        /// İndirimlerden önceki sepet tutarını getirir.
        /// </summary>
        /// <returns></returns>
        public double GetBaseTotalAmount()
        {
            return this.OriginalCartPrice;
        }

        /// <summary>
        /// İndirim sonrası sepet tutarını getirir.
        /// </summary>
        /// <returns></returns>
        public double GetTotalAmountAfterDiscounts()
        {
            return TotalPrice;
        }

        /// <summary>
        /// Kupon İndirim Tutarını getirir.
        /// </summary>
        /// <returns></returns>
        public double GetCouponDiscount()
        {
            return CouponDiscount;
        }

        /// <summary>
        /// Kampanya indirim tutarını getirir.
        /// </summary>
        /// <returns></returns>
        public double GetCampaignDiscount()
        {
            return CampaignDiscount;
        }

        /// <summary>
        /// Kargo ücretini getirir.
        /// </summary>
        /// <returns></returns>
        public double GetDeliveryCost()
        {
            return DeliveryCost;
        }

        /// <summary>
        /// Sepet içindeki ürünleri kategoriye göre gruplayıp ekrana yazdırır.
        /// </summary>
        public void Print()
        {
            var cartLinesGroups = this.CartLines.GroupBy(item => item.Product.Category,
                (key, group) => new { Category = key, Items = group.ToList() }).ToList();

            foreach (var cartLinesGroup in cartLinesGroups)
            {
                foreach (var cartLine in cartLinesGroup.Items)
                {
                    Console.WriteLine("Kategori Adı : " + cartLinesGroup.Category.Title);
                    Console.WriteLine("Ürün adı     : " + cartLine.Product.Title);
                    Console.WriteLine("Ürün fiyatı  : " + cartLine.Product.Price);
                    Console.WriteLine("Adedi        : " + cartLine.Quantity);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Toplam fiyat   :  " + (this.OriginalCartPrice + this.DeliveryCost));
            Console.WriteLine("Toplam indirim : -" + (this.CampaignDiscount + this.CouponDiscount));
            Console.WriteLine("Ödenecek tutar :  " + (this.TotalPrice + this.DeliveryCost));
        }
    }
}