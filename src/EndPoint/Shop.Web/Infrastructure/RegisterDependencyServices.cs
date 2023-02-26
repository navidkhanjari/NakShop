using Shop.Web.Infrastructure.RazorUtils;
using Microsoft.Extensions.DependencyInjection;
using Shop.Web.Infrastructure.ShopCart;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Shop.Web.Infrastructure
{

    public static class RegisterDependencyServices
    {
        public static IServiceCollection RegisterWebDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
            services.AddTransient<IRenderViewToString, RenderViewToString>();


            services.AddHttpContextAccessor();
            services.AddTransient<ShopCartManager>();

            services.AddCookieManager();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

            return services;
        }
    }
}