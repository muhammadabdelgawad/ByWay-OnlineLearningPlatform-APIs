using ByWay.Application.Mapping;
using ByWay.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace ByWay.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            return services;
        }
    }
}
