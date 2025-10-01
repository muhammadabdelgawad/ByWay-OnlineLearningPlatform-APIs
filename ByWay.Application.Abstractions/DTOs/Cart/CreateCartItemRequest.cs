namespace ByWay.Application.Abstraction.DTOs.Cart
{
    public class CreateCartItemRequest
    {

        public string CourseName { get; set; } = string.Empty;
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
