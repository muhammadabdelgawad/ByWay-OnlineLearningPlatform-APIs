using ByWay.Domain.Entities.Identity;

namespace ByWay.Infrastructure.Identity.Configurations
{
    internal class CourseEnrollmentConfigurations : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            builder.ToTable("CourseEnrollments");

            builder.HasKey(ce=>ce.CourseId);

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
                .HasForeignKey(ce => ce.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ce => ce.Course)
                .WithMany() 
                .HasForeignKey(ce => ce.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasIndex(ce => ce.EnrollmentDate)
                .HasDatabaseName("IX_CourseEnrollment_EnrollmentDate");

        }
    }
}
