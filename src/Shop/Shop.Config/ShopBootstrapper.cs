using Common.Application._Utilities;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.Orders;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Application.Users.Register;
using Shop.Domain.CategoryAgg;
using Shop.Domain.OrderAgg.Services;
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
    public class ShopBootstrapper
    {
        public static void Init( IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);
            FacadeBootstrapper.InitFacadeDependency(services);
          
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();
            services.AddTransient<IOrderDomainService, OrderDomainService>();
            services.AddTransient<ILocalFileService, LocalFileService>();

            services.AddMediatR(typeof(RegisterUserCommand).Assembly);

            services.AddMediatR(typeof(Directories).Assembly);

            services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);

     
        }
    }
}
