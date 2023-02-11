using Common.Query;
using System;

namespace Shop.Query.Orders.DTOs
{
    public class OrderItemDto : BaseDto
    {
        public ProductOrderItem Product { get; set; }
        public string ShopName { get; set; }
        public Guid OrderId { get; set; }
        public Guid InventoryId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Price * Count;
    }
}
