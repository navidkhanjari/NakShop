using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommand : IBaseCommand
    {
        public AddSellerInventoryCommand(Guid sellerId, Guid productId, int count,
            int price, int? discountPercentage)
        {
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
        public Guid SellerId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }
    }
}
