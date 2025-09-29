using ByWay.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Identity.Configurations
{
    public class CourseEnrollmentConfigurations : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            builder.ToTable("CourseEnrollments");

            // Fix: Use composite primary key (UserId + CourseId)
            builder.HasKey(ce => new { ce.UserId, ce.CourseId });

            // Property configurations
            builder.Property(ce => ce.UserId)
                .IsRequired()
                .HasMaxLength(450); // Match Identity column length

            builder.Property(ce => ce.CourseId)
                .IsRequired();

            builder.Property(ce => ce.EnrollmentDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(ce => ce.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(ce => ce.CompletionDate)
                .IsRequired(false);

            // Fix: Use foreign key properties instead of navigation properties
            builder.HasOne(ce => ce.User)
                .WithMany(u => u.CourseEnrollments)
                .HasForeignKey(ce => ce.UserId) // Changed from ce.User to ce.UserId
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ce => ce.Course)
                .WithMany()
                .HasForeignKey(ce => ce.CourseId) // This was already correct
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(ce => ce.EnrollmentDate)
                .HasDatabaseName("IX_CourseEnrollment_EnrollmentDate");

            builder.HasIndex(ce => new { ce.UserId, ce.IsCompleted })
                .HasDatabaseName("IX_CourseEnrollment_UserId_IsCompleted");
        }
    }
}
