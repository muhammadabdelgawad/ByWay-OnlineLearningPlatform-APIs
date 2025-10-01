namespace ByWay.Application.Abstraction.DTOs.Cart
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public required string CourseName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? PictureUrl { get; set; }
        public  string Course { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
