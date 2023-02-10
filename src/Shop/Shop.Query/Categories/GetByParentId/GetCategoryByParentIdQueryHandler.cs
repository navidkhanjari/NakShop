using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Categories.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetCategoryByParentIdQueryHandler : IBaseQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryByParentIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);

            return result.MapChildren();
        }

    }
}