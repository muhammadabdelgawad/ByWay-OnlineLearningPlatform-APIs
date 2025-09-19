using ByWay.Domain.Entities;
using ByWay.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Configurations.Courses
{
    public class CourseSectionConfigurations : BaseConfigurations<CourseSection>
    {
        public void Configure(EntityTypeBuilder<CourseSection> builder)
        {
            builder.Property(cs => cs.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(cs => cs.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(cs => cs.SectionNumber)
                   .IsRequired();
            
            builder.Property(cs => cs.LecturesCount)
                   .IsRequired();
            
            builder.Property(cs => cs.TotalDuration)
                   .IsRequired();

            builder.HasOne(cs => cs.Course)
              .WithMany(c => c.Sections)
              .HasForeignKey(cs => cs.CourseId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(cs => cs.Lectures)
                .WithOne(l => l.CourseSection)
                .HasForeignKey(l => l.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}

