using ByWay.Infrastructure.Data.Configurations.Base;

namespace ByWay.Infrastructure.Data.Configurations.Courses
{
    public class CourseConfigurations : BaseConfigurations<Course>, IEntityTypeConfiguration<Course>
    {
        public new void Configure(EntityTypeBuilder<Course> builder)
        {
            
            base.Configure(builder);

            builder.Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.PictureUrl)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Price)
                   .IsRequired()
                   .HasPrecision(18, 2)
                   .HasDefaultValue(0);

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
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(c => c.Sections)          
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Lectures)
                   .WithOne(l => l.Course)
                   .HasForeignKey(l => l.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
