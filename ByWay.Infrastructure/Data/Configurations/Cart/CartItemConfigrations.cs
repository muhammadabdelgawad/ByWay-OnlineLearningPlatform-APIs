using ByWay.Domain.Entities.Cart;

namespace ByWay.Infrastructure.Data.Configurations.Cart
{
    public class CartItemConfigrations : IEntityTypeConfiguration<CartItem>

    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.CourseName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ci => ci.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(ci => ci.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(ci => ci.PictureUrl)
                .HasMaxLength(500);

            builder.HasOne(ci => ci.Course)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
