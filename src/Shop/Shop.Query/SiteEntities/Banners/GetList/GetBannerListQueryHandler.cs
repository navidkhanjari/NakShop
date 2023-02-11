using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.SiteEntities.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Banners.GetList
{
    public class GetBannerListQueryHandler : IBaseQueryHandler<GetBannerListQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;

        public GetBannerListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.OrderByDescending(d => d.Id)
                .Select(banner => new BannerDto()
                {
                    Id = banner.Id,
                    CreationDate = banner.CreationDate,
                    ImageName = banner.ImageName,
                    Link = banner.Link,
                    Position = banner.Position
                }).ToListAsync(cancellationToken);
        }
    }
}
