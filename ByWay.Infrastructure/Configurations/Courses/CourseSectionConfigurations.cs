namespace ByWay.Infrastructure.Configurations.Courses
{
    public class CourseSectionConfigurations : BaseConfigurations<CourseSection>, IEntityTypeConfiguration<CourseSection>
    {
        public new void Configure(EntityTypeBuilder<CourseSection> builder)
        {
            
            base.Configure(builder);

            builder.Property(cs => cs.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(cs => cs.SectionNumber)
                   .IsRequired();
            
            builder.Property(cs => cs.LecturesCount)
                   .IsRequired();
            
            builder.Property(cs => cs.TotalDuration)
                   .IsRequired();

           
            builder.HasMany(cs => cs.Lectures)
                .WithOne(l => l.CourseSection)
                .HasForeignKey(l => l.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}

