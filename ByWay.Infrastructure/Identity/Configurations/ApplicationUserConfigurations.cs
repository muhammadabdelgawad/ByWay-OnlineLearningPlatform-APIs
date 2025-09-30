using ByWay.Domain.Entities.Identity;

namespace ByWay.Infrastructure.Identity.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
           
            
            builder.Property(u => u.DisplayName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PictureUrl)
                .HasMaxLength(500);

            builder.Property(u => u.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.LastLoginDate)
                .IsRequired(false);

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
