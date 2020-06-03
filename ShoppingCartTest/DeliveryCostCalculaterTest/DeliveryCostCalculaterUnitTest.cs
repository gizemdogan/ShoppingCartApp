using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartProject.Models;
using ShoppingCartProject.Utility;

namespace ShoppingCartTest.DeliveryCostCalculaterTest
{
    [TestClass]
    public class DeliveryCostCalculaterUnitTest
    {
        [TestMethod]
        public void CalculateForTest()
        {
            Category category = new Category("fruit");

            Product apple = new Product("Apple", 100, category);
            Product almond = new Product("Almond", 150, category);

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            DeliveryCostCalculater deliveryCostCalculater = new DeliveryCostCalculater(2, 3, Consts.DeliveryFixedCost);

            deliveryCostCalculater.CalculateFor(cart);

            Assert.AreEqual(8.99, cart.DeliveryCost);

        }
    }
}
