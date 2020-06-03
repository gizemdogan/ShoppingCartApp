using ShoppingCartProject.Interfaces;
using System.Linq;

namespace ShoppingCartProject.Models
{
    /// <summary>
    /// Kargo Ücreti hesaplama
    /// </summary>
    public class DeliveryCostCalculater : IDeliveryCostCalculater
    {
        /// <summary>
        /// Her teslimat içn birim ücret
        /// </summary>
        public double CostPerDelivery { get; set; }

        /// <summary>
        /// Her ürün için birim ücret
        /// </summary>
        public double CostPerProduct { get; set; }
        
        /// <summary>
        /// Sabit ücret
        /// </summary>
        public double FixedCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="costPerDelivery"></param>
        /// <param name="costPerProduct"></param>
        /// <param name="fixedCost"></param>
        public DeliveryCostCalculater(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            this.CostPerDelivery = costPerDelivery;
            this.CostPerProduct = costPerDelivery;
            this.FixedCost = fixedCost;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shoppingCart"></param>
        public void CalculateFor(IShoppingCart shoppingCart)
        {
            int numberOfDelivery = shoppingCart.CartLines.GroupBy(x => x.Product.Category.Title).Count();
            int numberOfProduct = shoppingCart.CartLines.GroupBy(x => x.Product.Title).Count();

            shoppingCart.DeliveryCost = (this.CostPerDelivery * numberOfDelivery) + (this.CostPerProduct * numberOfProduct) + this.FixedCost;
            ;
        }
    }
}
