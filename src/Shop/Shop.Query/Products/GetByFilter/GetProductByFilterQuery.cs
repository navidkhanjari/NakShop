using Common.Query;
using Common.Query.Filters;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Products.GetByFilter
{
    public class GetProductByFilterQuery : BaseQueryFilter<ProductFilterResult, ProductFilterParams>
    {
        public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
