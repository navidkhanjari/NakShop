
using Shop.Query.SiteEntities.DTOs;
using System.Collections.Generic;

namespace Shop.Web.ViewModels
{

    public class ShopMainPageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<BannerDto> Banners { get; set; }
        //public List<ProductShopDto> LatestProducts { get; set; }
        //public List<ProductShopDto> SpecificationProducts { get; set; }
        //public List<ProductShopDto> PopularProducts { get; set; }
        //public List<ProductShopDto> ProductsByCategory { get; set; }
    }
    public class LibraryMainPageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<BannerDto> Banners { get; set; }

    }

    public class MainPageCategoryProducts
    {
        public string CategorySlug { get; set; }
        public string Category { get; set; }
 
    }
}