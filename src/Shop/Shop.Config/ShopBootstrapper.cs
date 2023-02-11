using Common.Application._Utilities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);
            //services.AddMediatR(typeof(Directories).Assembly);
            //services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);
            //services.AddTransient<IProductDomainService, ProductDomainService>();
            //services.AddTransient<IUserDomainService, UserDomainService>();
            //services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            //services.AddTransient<ISellerDomainService, SellerDomainService>();


            //services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

            //services.InitFacadeDependency();
        }
    }
}
