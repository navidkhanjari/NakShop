using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Orders;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.Sellers.Inventories;
using Shop.Presentation.Facade.SiteEntities.Banner;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade
{
    public  class FacadeBootstrapper
    {
        public static void InitFacadeDependency( IServiceCollection services)
        {
      
            services.AddTransient<ICategoryFacade, CategoryFacade>();
            services.AddTransient<IOrderFacade, OrderFacade>();
            services.AddTransient<IProductFacade, ProductFacade>();
            services.AddTransient<IRoleFacade, RoleFacade>();
            services.AddTransient<ISellerFacade, SellerFacade>();
            services.AddTransient<IBannerFacade, BannerFacade>();
            services.AddTransient<ISliderFacade, SliderFacade>();
            services.AddTransient<ISellerInventoryFacade, SellerInventoryFacade>();
            services.AddTransient<IUserFacade, UserFacade>();
            services.AddTransient<IUserAddressFacade, UserAddressFacade>();

        }
    }
}
