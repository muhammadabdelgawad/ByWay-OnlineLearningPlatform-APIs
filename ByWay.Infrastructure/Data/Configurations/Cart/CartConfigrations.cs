
using ByWay.Domain.Entities.Cart;

namespace ByWay.Infrastructure.Data.Configurations.Cart
{
    public class CartConfigrations : IEntityTypeConfiguration<Carts>
    {

        public void Configure(EntityTypeBuilder<Carts> builder)
        {
           builder.HasKey(c => c.Id);
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(500); 

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.Discount)
                .HasColumnType("decimal(6,2)")
                .HasDefaultValue(0);

           
            builder.HasMany(c => c.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
