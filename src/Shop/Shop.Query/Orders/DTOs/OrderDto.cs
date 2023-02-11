﻿using Common.Query;
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
        //public ShippingMethod? ShippingMethod { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
    public class OrderFilterResult : BaseFilter<OrderFilterData, OrderFilterParams>
    {

    }
}
