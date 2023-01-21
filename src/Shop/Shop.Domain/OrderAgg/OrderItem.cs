using Common.Domain;
using Common.Domain.Exceptions;
using System;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        public OrderItem(Guid inventoryId, int count, int price, int discountPercentage)
        {
            PriceGuard(price);
            CountGuard(count);
            DiscountGuard(discountPercentage);

            InventoryId = inventoryId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
        public Guid OrderId { get; internal set; }
        public Guid InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int DiscountPercentage { get; private set; }
        public int TotalPrice
        {
            get
            {
                var discount = 0;
                var totalPrice = Price;
                if (DiscountPercentage is > 0)
                    discount = (int)DiscountPercentage * Price / 100;

                totalPrice -= discount;
                return totalPrice * Count;
            }
        }

        public void IncreaseCount(int count)
        {
            Count += count;
        }

        public void DecreaseCount(int count)
        {
            if (Count == 1)
                return;
            if (Count - count <= 0)
                return;

            Count -= count;
        }

        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);

            Count = newCount;
        }

        public void ChangePrice(int newPrice, int discountPercentage)
        {
            PriceGuard(newPrice);
            DiscountGuard(discountPercentage);

            Price = newPrice;
            DiscountPercentage = discountPercentage;
        }

        private void PriceGuard(int newPrice)
        {
            if (newPrice < 1)
                throw new InvalidDomainDataException("مبلغ کالا نامعتبر است");
        }

        private void CountGuard(int count)
        {
            if (count < 1)
                throw new InvalidDomainDataException();
        }
        private void DiscountGuard(int? discountPercentage)
        {
            if (discountPercentage is < 0)
                throw new InvalidDomainDataException("درصد تخفیف نامعتبر است");
        }
    }
}
