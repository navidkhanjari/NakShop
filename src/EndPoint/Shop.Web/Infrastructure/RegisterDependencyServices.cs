using Shop.Web.Infrastructure.JwtUtil;
using Shop.Web.Infrastructure.RazorUtils;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Web.Infrastructure
{

    public static class RegisterDependencyServices
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
            services.AddTransient<IRenderViewToString, RenderViewToString>();



            return services;
        }
    }
}