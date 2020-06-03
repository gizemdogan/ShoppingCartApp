using ShoppingCartProject.Interfaces;
using System.Linq;

namespace ShoppingCartProject.Models
{
    public class DeliveryCostCalculater : IDeliveryCostCalculater
    {
        public double CostPerDelivery { get; set; }

        public double CostPerProduct { get; set; }

        public double TotalDeliveryCost { get; set; }

        public double FixedCost { get; set; }

        public DeliveryCostCalculater(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            this.CostPerDelivery = costPerDelivery;
            this.CostPerProduct = costPerDelivery;
            this.FixedCost = fixedCost;
        }

        public void CalculateFor(IShoppingCart shoppingCart)
        {
            int numberOfDelivery = shoppingCart.CartLines.GroupBy(x => x.Product.Category.Title).Count();
            int numberOfProduct = shoppingCart.CartLines.GroupBy(x => x.Product.Title).Count();

            shoppingCart.DeliveryCost = (this.CostPerDelivery * numberOfDelivery) + (this.CostPerProduct * numberOfProduct) + this.FixedCost;
            ;
        }

    }
}
