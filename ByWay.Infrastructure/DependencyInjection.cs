
namespace ByWay.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("HostConnection")));


            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            

            //Identity

            services.AddDbContext<IdentityAppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("HostIdentityConnection")));
           


            return services;
        }
    }
}
