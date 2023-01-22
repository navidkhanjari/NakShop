using Common.Domain;
using Common.Domain.Exceptions;
using System;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {

        public Guid SellerId { get; internal set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int DiscountPercentage { get; private set; }

        private SellerInventory()
        {
        }
        public SellerInventory(Guid productId, int count, int price, int discountPercentage)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();

            if (discountPercentage < 0)
                throw new InvalidDomainDataException("درصد تخفیف نمی تواند کمتر از 0 باشد");

            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }


        public void Edit(int count, int price, int discountPercentage)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();
            if (discountPercentage < 0)
                throw new InvalidDomainDataException("درصد تخفیف نمی تواند کمتر از 0 باشد");

            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
    }
}
