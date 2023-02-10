using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Categories.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetList
{
    internal class GetCategoryListQueryHandler : IBaseQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
            return model.Map();
        }
    }
}
