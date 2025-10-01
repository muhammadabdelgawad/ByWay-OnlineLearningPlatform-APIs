namespace ByWay.Domain.Entities.Cart
{
    public class CartItem
    {
        public int Id { get; set; }
        public required string CourseName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? PictureUrl { get; set; }
        public virtual Course Course { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
