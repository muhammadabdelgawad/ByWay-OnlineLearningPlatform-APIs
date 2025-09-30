using ByWay.Domain.Entities.Identity;
using ByWay.Infrastructure.Identity.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ByWay.Infrastructure.Identity
{
    public class IdentityAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserConfigurations());
            modelBuilder.ApplyConfiguration(new CourseEnrollmentConfigurations());
        }

         
    }
}
