using ByWay.Domain.Entities.Identity;
using ByWay.Infrastructure.Identity.Configurations;

namespace ByWay.Infrastructure.Identity
{
    public class IdentityAppDbContext :DbContext
    {
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseEnrollmentConfigurations).Assembly);
        }

        public DbSet<ApplicationUser>Users { get; set; }
        public DbSet<CourseEnrollment>CourseEnrollments { get; set; }
    }
}
