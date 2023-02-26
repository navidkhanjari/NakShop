using Shop.Query.Orders.DTOs;
using System;

namespace Shop.Web.ViewModels.ShopCart
{

    public class ShopCartItemViewModel
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public OrderProduct Product { get; set; }
        public string ShopName { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int Count { get; set; }
        public int TotalPrice
        {
            get
            {
                var discount = DiscountPercentage * Price / 100;
                var price = Price - discount;
                return price * Count;
            }
        }

        public int GetDiscountAmount()
        {
            var discount = DiscountPercentage * Price / 100;
            return discount * Count;
        }
    }
}