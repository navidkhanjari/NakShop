using Common.Query.Filters;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Sellers.DTOs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetByFIlter
{
    public class SellerByFilterQueryHandler : IBaseQueryFilterHandler<GetSellerByFilterQuery, SellerFilterResult>
    {
        private ShopContext _context;

        public SellerByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(d => d.Id).AsQueryable();

          

            if (!string.IsNullOrWhiteSpace(@params.ShopName))
                result = result.Where(r => r.ShopName.Contains(@params.ShopName));


            var skip = (@params.PageId - 1) * @params.Take;

            var sellerResult = new SellerFilterResult()
            {
                Filters = @params,
                Data = await result.Skip(skip).Take(@params.Take)
                    .Select(seller => seller.Map())
                    .ToListAsync(cancellationToken)
            };

            sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
            return sellerResult;
        }
    }
}
