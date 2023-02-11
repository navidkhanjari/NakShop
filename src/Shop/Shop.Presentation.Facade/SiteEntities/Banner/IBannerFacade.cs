using Common.Application;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SiteEntities.Banner
{
    public interface IBannerFacade
    {
        Task<OperationResult> CreateBanner(CreateBannerCommand command);
        Task<OperationResult> EditBanner(EditBannerCommand command);

        Task<BannerDto?> GetBannerById(Guid id);
        Task<List<BannerDto>> GetBanners();
    }
}
