using ByWay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Configurations.Base
{
    public class BaseConfigurations<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                   .IsRequired();

            builder.Property(e => e.UpdatedDate)
                   .IsRequired();

            builder.Property(e => e.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);
        }
    }
}
