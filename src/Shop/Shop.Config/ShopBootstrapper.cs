using Common.Application._Utilities;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Application.Users.Register;
using Shop.Domain.CategoryAgg;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Service;
using Shop.Infrastructure;
using Shop.Presentation.Facade;
using Shop.Query.Categories.GetById;
using System.Reflection;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);
            FacadeBootstrapper.InitFacadeDependency(services);
            services.AddTransient<IProductDomainService, ProductDomainService>();
   
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();


            services.AddTransient<ILocalFileService, LocalFileService>();

            services.AddMediatR(typeof(Directories).Assembly);
           
            services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

     
        }
    }
}
