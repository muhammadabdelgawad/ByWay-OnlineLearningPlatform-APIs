namespace ByWay.Infrastructure.Configurations.Lecture
{
    public class LectureConfigurations : IEntityTypeConfiguration<Lectur>
    {
        public void Configure(EntityTypeBuilder<Lectur> builder)
        {
            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(300);
            
            builder.Property(l => l.Duration)
                .IsRequired();
            builder.Property(l => l.IsCompeleted)
                .HasDefaultValue(false);

            builder.HasOne(l => l.CourseSection)
                   .WithMany(cs => cs.Lectures)
                   .HasForeignKey(l => l.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
