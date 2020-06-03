using System.Collections.Generic;

namespace ShoppingCartProject.Interfaces
{
    public interface IShoppingCart
    {
        List<ICartLine> CartLines { get; set; }
        double TotalPrice { get; set; }
        double CouponDiscount { get; set; }
        double CampaignDiscount { get; set; }
        double DeliveryCost { get; set; }
        double OriginalCartPrice { get; set; }
        void AddItem(IProduct product, int quantity);
        void ApplyDiscounts(params ICampaign[] campaigns);
        void ApplyCoupon(ICoupon coupon);
        double GetBaseTotalAmount();
        double GetTotalAmountAfterDiscounts();
        double GetCouponDiscount();
        double GetCampaignDiscount();
        double GetDeliveryCost();
        void Print();
    }
}