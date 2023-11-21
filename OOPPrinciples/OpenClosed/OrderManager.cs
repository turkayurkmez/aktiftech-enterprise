namespace OpenClosed
{
    //public enum CampaignTypes
    //{
    //    TwoProductForOnePrice,
    //    FreeDelivery,
    //    ThreeProductsForOnePrice

    //}

    public abstract class CampaignTypes
    {
        public abstract decimal GetDiscountedPrice(decimal price);

    }
    public class TwoForOnePriceCampaign : CampaignTypes
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price * .5M;
        }
    }
    public class FreeDeliveryCampaign : CampaignTypes
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price * .85M;
        }
    }

    public class ThreeForOnePriceCampaign : CampaignTypes
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price / 3;
        }
    }

    public class Customer
    {
        public CampaignTypes Campaign { get; set; }
    }
    public class OrderManager
    {
        public Customer Customer { get; set; }
        public decimal GetDiscountedPrice(decimal price)
        {
            return Customer.Campaign.GetDiscountedPrice(price);
            //switch (Customer.Campaign)
            //{
            //    case CampaignTypes.TwoProductForOnePrice:
            //        return price * .5M;
            //    case CampaignTypes.FreeDelivery:

            //        return price * 0.85M;
            //    case CampaignTypes.ThreeProductsForOnePrice:
            //        return price * .25M;
            //    default:
            //        return price;
            //}
        }
    }
}
