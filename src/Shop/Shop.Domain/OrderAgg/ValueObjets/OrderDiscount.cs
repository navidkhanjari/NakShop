using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjets
{
    public class OrderDiscount : ValueObject
    {
        public OrderDiscount(string discountTitle, int discountAmount)
        {
            DiscountTitle = discountTitle;
            DiscountAmount = discountAmount;
        }

        public string DiscountTitle { get; private set; }
        public int DiscountAmount { get; private set; }
    }
}
