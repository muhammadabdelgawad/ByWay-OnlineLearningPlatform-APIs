namespace ByWay.Infrastructure.Configurations.Categories
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.PictureUrl)
                     .IsRequired()
                     .HasMaxLength(300);

            builder.HasMany(c => c.Courses)
                .WithOne(cs => cs.Category)
                     .HasForeignKey(c => c.CategoryId)
                     .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
