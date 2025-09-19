using ByWay.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Configurations.Courses
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
           builder.Property(c=>c.CourseName)
               .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.PictureUrl)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Price)
                .IsRequired()
                .HasPrecision(6, 2);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(c => c.Certification)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.TotalHours)
                .IsRequired();

            builder.Property(c => c.Level)
                .IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
