using ByWay.Domain.Entities.Identity;

namespace ByWay.Infrastructure.Identity.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PictureUrl)
                 .HasMaxLength(500);

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(u => u.CourseEnrollments)
              .WithOne(c => c.User)
              .HasForeignKey(c => c.User)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
