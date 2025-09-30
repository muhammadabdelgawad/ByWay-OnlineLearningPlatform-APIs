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

          
            builder.HasKey(ce => ce.Id);
            builder.Property(ce => ce.Id).ValueGeneratedOnAdd();

          
            builder.Property(ce => ce.UserId)
                .IsRequired()
                .HasMaxLength(450); 

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

            builder.HasOne(ce => ce.User)
                .WithMany(u => u.CourseEnrollments)
                .HasForeignKey(ce => ce.UserId) 
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasIndex(ce => ce.EnrollmentDate)
                .HasDatabaseName("IX_CourseEnrollment_EnrollmentDate");

            builder.HasIndex(ce => new { ce.UserId, ce.IsCompleted })
                .HasDatabaseName("IX_CourseEnrollment_UserId_IsCompleted");

            builder.HasIndex(ce => ce.CourseId)
                .HasDatabaseName("IX_CourseEnrollment_CourseId");
        }
    }
}
