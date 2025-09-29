using ByWay.Application.Mapping;
using ByWay.Infrastructure.Identity;
using ByWay.Infrastructure.Repositories.UnitOfWork;
using ByWay.Infrastructure.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByWay.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddAutoMapper(typeof(MappingProfile));

            //Identity

            services.AddDbContext<IdentityAppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            return services;
        }
    }
}
