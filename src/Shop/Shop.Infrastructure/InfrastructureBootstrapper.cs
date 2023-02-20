using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.Aggregates.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.SiteEntities.Repositories;
using Shop.Infrastructure.Persistent.Ef.Aggregates.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.UserAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services,string connectionString)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

       
            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
