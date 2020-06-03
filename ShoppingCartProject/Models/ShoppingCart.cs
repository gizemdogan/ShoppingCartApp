using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartProject.Models
{
    public partial class ShoppingCart : IShoppingCart
    {
        public List<ICartLine> CartLines { get; set; }

        public double TotalPrice { get; set; }

        public double CouponDiscount { get; set; }

        public double CampaignDiscount { get; set; }

        public double DeliveryCost { get; set; }

        public double OriginalCartPrice
        {
            get
            {
                return CartLines.Sum(x => x.Product.Price * x.Quantity);

            }
            set { }
        }

        public ShoppingCart()
        {
            CartLines = new List<ICartLine>();
        }


        public void AddItem(IProduct product, int quantity)
        {
            CartLines.Add(new CartLine()
            {
                Product = product,
                Quantity = quantity
            });

            this.TotalPrice = this.OriginalCartPrice;
        }

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

        public void ApplyCoupon(ICoupon coupon)
        {
            if (TotalPrice >= coupon.MinPurchase)
            {
                double discount = calculateDiscount(TotalPrice, coupon.Rate, coupon.DiscountType);
                TotalPrice -= discount;
                CouponDiscount = discount;
            }
        }

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

        public double GetBaseTotalAmount()
        {
            return this.OriginalCartPrice;
        }

        public double GetTotalAmountAfterDiscounts()
        {
            return TotalPrice;
        }

        public double GetCouponDiscount()
        {
            return CouponDiscount;
        }

        public double GetCampaignDiscount()
        {
            return CampaignDiscount;
        }

        public double GetDeliveryCost()
        {
            return DeliveryCost;
        }

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