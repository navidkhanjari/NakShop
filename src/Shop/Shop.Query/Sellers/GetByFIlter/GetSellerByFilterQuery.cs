using Common.Query.Filters;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Sellers.GetByFIlter
{
    public class GetSellerByFilterQuery : BaseQueryFilter<SellerFilterResult, SellerFilterParams>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
