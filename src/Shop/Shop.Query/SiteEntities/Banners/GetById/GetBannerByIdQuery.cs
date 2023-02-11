using Common.Query;
using Shop.Query.SiteEntities.DTOs;
using System;

namespace Shop.Query.SiteEntities.Banners.GetById
{
    public record GetBannerByIdQuery(Guid BannerId) : IBaseQuery<BannerDto>;
}
