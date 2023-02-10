using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Categories.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetById
{
    internal class GetCategoryByIdQueryHandler : IBaseQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ShopContext _context;

        public GetCategoryByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories
                .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);
            return model.Map();
        }
    }
}
