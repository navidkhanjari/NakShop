using Common.Query.Filters;
using Shop.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Orders.GetByFilter
{

    public class GetOrdersByFilterQuery : BaseQueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }

}
