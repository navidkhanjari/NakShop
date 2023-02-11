using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Sellers.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetById
{
    public class GetSellerByIdQueryHandler : IBaseQueryHandler<GetSellerByIdQuery, SellerDto?>
    {
        private ShopContext _shopContext;

        public GetSellerByIdQueryHandler(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _shopContext.Sellers.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
            return seller.Map();
        }
    }
}
