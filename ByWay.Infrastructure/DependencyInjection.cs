
namespace ByWay.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure())
            );

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();



            services.AddDbContext<IdentityAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure())
            );

            return services;
        }
    }
}
