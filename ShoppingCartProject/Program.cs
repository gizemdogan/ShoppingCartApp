using ShoppingCartProject.Interfaces;
using ShoppingCartProject.Models;
using ShoppingCartProject.Utility;
using System;

namespace ShoppingCartProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ICategory parentCategoryRoot = new Category("food&drink");

            ICategory parentCategory = new Category("food")
            {
                ParentCategory = parentCategoryRoot
            };

            ICategory category = new Category("fruit")
            {
                ParentCategory = parentCategory
            };

            IProduct apple = new Product("Apple", 100, category);
            IProduct almond = new Product("Almond", 150, category);

            ICampaign campaign1 = new Campaign(parentCategoryRoot, 20, 3, DiscountType.Rate);
            ICampaign campaign2 = new Campaign(parentCategoryRoot, 50, 5, DiscountType.Rate);
            ICampaign campaign3 = new Campaign(parentCategoryRoot, 5, 5, DiscountType.Amount);
            ICoupon coupon = new Coupon(100, 10, DiscountType.Amount);
            IDeliveryCostCalculater deliveryCostCalculater = new DeliveryCostCalculater(2, 3, Consts.DeliveryFixedCost);


            IShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            cart.ApplyDiscounts(campaign1, campaign2, campaign3);
            cart.ApplyCoupon(coupon);
            deliveryCostCalculater.CalculateFor(cart);
            cart.Print();
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
