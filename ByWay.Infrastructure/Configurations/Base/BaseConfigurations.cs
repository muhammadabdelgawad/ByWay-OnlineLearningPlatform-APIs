using Microsoft.EntityFrameworkCore;

namespace ByWay.Infrastructure.Configurations.Base
{
    public class BaseConfigurations<TEntity> : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);
        }
    }
}
