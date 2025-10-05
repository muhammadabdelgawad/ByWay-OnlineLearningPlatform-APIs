using System.Reflection;

namespace ByWay.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(ICartService), typeof(CartService));
            services.AddScoped(typeof(IAdminService), typeof(AdminService));

            return services;
        }
        public static IServiceCollection AddFluentValidationConf(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
