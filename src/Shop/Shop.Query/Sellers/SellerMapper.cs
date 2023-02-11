using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers
{
    public static class SellerMapper
    {
        public static SellerDto Map(this Seller seller)
        {
            if (seller == null)
                return null;

            return new SellerDto()
            {
                Id = seller.Id,
                CreationDate = seller.CreationDate,
                Status = seller.Status,
                ShopName = seller.ShopName,
                UserId = seller.UserId
            };
        }
    }
}
