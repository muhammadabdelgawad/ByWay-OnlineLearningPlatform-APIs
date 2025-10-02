using ByWay.Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByWay.Infrastructure.Data.Configurations.Cart
{
    public class CartItemConfigrations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.CourseId)
                .IsRequired();

            builder.Property(ci => ci.CourseName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ci => ci.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(ci => ci.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(ci => ci.PictureUrl)
                .HasMaxLength(500);

          
            builder.HasOne(ci => ci.Course)
                .WithMany(c => c.CartItems)  
                .HasForeignKey(ci => ci.CourseId)  
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(ci => ci.TotalPrice);
        }
    }
}
