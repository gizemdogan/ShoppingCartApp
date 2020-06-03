using ShoppingCartProject.Models;

namespace ShoppingCartProject.Interfaces
{
    public interface IDeliveryCostCalculater
    {
        double CostPerDelivery { get; set; }
        double CostPerProduct { get; set; }
        double FixedCost { get; set; }
        void CalculateFor(IShoppingCart shoppingCart);
    }
}
