
namespace ByWay.Domain.Entities.Cart
{
    public class Carts
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public decimal Discount { get; set; }
        public string? ApplicationUser { get; set; }
        public required IEnumerable<CartItem> Items { get; set; }= new List<CartItem>();



    }
}
