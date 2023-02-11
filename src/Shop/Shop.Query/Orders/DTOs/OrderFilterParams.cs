using Common.Query.Filters;
using System;

namespace Shop.Query.Orders.DTOs
{
    public class OrderFilterParams : BaseFilterParam
    {
        public Guid? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrderStatus? Status { get; set; }

    }
}
