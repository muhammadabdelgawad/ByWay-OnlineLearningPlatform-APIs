using ByWay.Domain.Entities.Identity;

namespace ByWay.Infrastructure.Identity 
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PictureUrl)
                .HasMaxLength(500);

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(u => u.CourseEnrollments)
                .WithOne(ce => ce.User)
                .HasForeignKey(ce => ce.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
