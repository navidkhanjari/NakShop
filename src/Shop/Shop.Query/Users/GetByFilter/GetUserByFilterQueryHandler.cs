using Common.Query;
using Common.Query.Filters;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Users.DTOs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetByFilter
{
    public class GetUserByFilterQueryHandler : IBaseQueryFilterHandler<GetUserByFilterQuery, UserFilterResult>
    {
        private readonly ShopContext _context;

        public GetUserByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Users.OrderByDescending(d => d.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.Email))
                result = result.Where(r => r.Email.Contains(@params.Email));

            if (!string.IsNullOrWhiteSpace(@params.PhoneNumber))
                result = result.Where(r => r.PhoneNumber.Contains(@params.PhoneNumber));

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new UserFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take)
                    .Select(user => user.MapFilterData()).ToListAsync(cancellationToken),
                Filters = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
