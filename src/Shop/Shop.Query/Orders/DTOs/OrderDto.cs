using Common.Query;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.DTOs
{

    public class OrderDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get; set; }
        public OrderAddress? Address { get; set; }
     
        public List<OrderItemDto> Items { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
    public class OrderItemDto : BaseDto
    {
        public string ProductTitle { get; set; }
        public string ProductSlug { get; set; }
        public string ProductImageName { get; set; }
        public string ShopName { get; set; }
        public Guid OrderId { get; set; }
        public Guid InventoryId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Price * Count;
    }
    public class OrderFilterResult : BaseFilter<OrderFilterData, OrderFilterParams>
    {

    }
}
