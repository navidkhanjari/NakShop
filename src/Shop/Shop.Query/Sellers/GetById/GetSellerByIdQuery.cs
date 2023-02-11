using Common.Query;
using Shop.Query.Sellers.DTOs;
using System;


namespace Shop.Query.Sellers.GetById
{
    public class GetSellerByIdQuery : IBaseQuery<SellerDto>
    {
        public GetSellerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
