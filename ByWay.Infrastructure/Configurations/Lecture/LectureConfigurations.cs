using ByWay.Domain.Entities;
using ByWay.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Configurations.Lecture
{
    public class LectureConfigurations : BaseConfigurations<Lectur>, IEntityTypeConfiguration<Lectur>
    {
        public new void Configure(EntityTypeBuilder<Lectur> builder)
        {
            base.Configure(builder);
            
            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(300);
            
            builder.Property(l => l.Duration)
                .IsRequired();


            builder.Property(l => l.IsCompleted)
                .HasDefaultValue(false);


            builder.Property(l => l.LectureNumber)
                .IsRequired();


            builder.HasOne(l => l.Course)
                   .WithMany(c => c.Lectures)
                   .HasForeignKey(l => l.CourseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.CourseSection)
                   .WithMany(cs => cs.Lectures)
                   .HasForeignKey(l => l.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(l => new { l.CourseId, l.LectureNumber })
                .IsUnique()
                .HasDatabaseName("IX_Lecture_CourseId_LectureNumber");
        }
    }
}
