using ByWay.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Configurations.Instructors
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(i => i.Name)
               .IsRequired()
               .HasMaxLength(100);
            
            builder.Property(i => i.Description)
                     .IsRequired()
                     .HasMaxLength(2000);

            builder.Property(i => i.PictureUrl)
                        .IsRequired()
                        .HasMaxLength(300);
        }
    }
}
