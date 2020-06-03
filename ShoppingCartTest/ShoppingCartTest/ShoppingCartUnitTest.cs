using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartProject.Models;
using ShoppingCartProject.Utility;

namespace ShoppingCartTest.ShoppingCartTest
{
    [TestClass]
    public class ShoppingCartUnitTest
    {
        [TestMethod]
        public void AddItemTest()
        {
            Category category = new Category("fruit");
            Product apple = new Product("Apple", 100, category);
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);

            int quantity = cart.CartLines.First().Quantity;

            Assert.AreEqual(3, quantity);
        }

        [TestMethod]
        public void ApplyDiscountsTest()
        {
            Category category = new Category("fruit");

            Product apple = new Product("Apple", 100, category);
            Product almond = new Product("Almond", 150, category);

            Campaign campaign1 = new Campaign(category, 20, 3, DiscountType.Rate);
            Campaign campaign2 = new Campaign(category, 50, 5, DiscountType.Rate);
            Campaign campaign3 = new Campaign(category, 5, 5, DiscountType.Amount);

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            cart.ApplyDiscounts(campaign1, campaign2, campaign3);

            Assert.AreEqual(360, cart.TotalPrice);

        }


        [TestMethod]
        public void ApplyCouponTest()
        {
            Category category = new Category("fruit");

            Product apple = new Product("Apple", 100, category);
            Product almond = new Product("Almond", 150, category);

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            Coupon coupon = new Coupon(100, 10, DiscountType.Amount);
            cart.ApplyCoupon(coupon);

            Assert.AreEqual(440, cart.TotalPrice);
        }

        [TestMethod]
        public void GetBaseTotalAmountTest()
        {
            Category category = new Category("fruit");

            Product apple = new Product("Apple", 100, category);
            Product almond = new Product("Almond", 150, category);

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);
            
            double originalCartPrice= cart.GetBaseTotalAmount();

            Assert.AreEqual(450, originalCartPrice);
        }

        [TestMethod]
        public void GetTotalAmountAfterDiscountsTest()
        {
            ShoppingCart cart = new ShoppingCart
            {
                TotalPrice = 500
            };
            double totalPrice = cart.GetTotalAmountAfterDiscounts();

            Assert.AreEqual(500, totalPrice);

        }

        [TestMethod]
        public void GetCouponDiscountTest()
        {
            ShoppingCart cart = new ShoppingCart
            {
                CouponDiscount = 10
            };
            double couponDiscount = cart.GetCouponDiscount();

            Assert.AreEqual(10, couponDiscount);
        }

        [TestMethod]
        public void GetCampaignDiscountTest()
        {
            ShoppingCart cart = new ShoppingCart
            {
                CampaignDiscount = 120
            };
            double campaignDiscount = cart.GetCampaignDiscount();

            Assert.AreEqual(120, campaignDiscount);
        }

        [TestMethod]
        public void GetDeliveryCostTest()
        {
            ShoppingCart cart = new ShoppingCart
            {
                DeliveryCost = 8.99
            };
            double deliveryCost = cart.GetDeliveryCost();

            Assert.AreEqual(8.99, deliveryCost);
        }

        [TestMethod]
        public void PrintTest()
        {
            bool isSuccess = true;
            Category category = new Category("fruit");

            Product apple = new Product("Apple", 100, category);
            Product almond = new Product("Almond", 150, category);

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            cart.Print();

            Assert.AreEqual(true, isSuccess);
        }
    }
}
