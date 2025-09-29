using ByWay.Domain.Entities.Identity;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
        }

        public DbSet<ApplicationUser>Users { get; set; }
        public DbSet<CourseEnrollment>CourseEnrollments { get; set; }
    }
}
