using Common.Query;
using Common.Query.Filters;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.DTOs
{
    public class SellerDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string ShopName { get; set; }
        public SellerStatus Status { get; set; }
    }

    public class SellerFilterResult : BaseFilter<SellerDto, SellerFilterParams>
    {

    }

    public class SellerFilterParams : BaseFilterParam
    {
        public string ShopName { get; set; }
    }
}
