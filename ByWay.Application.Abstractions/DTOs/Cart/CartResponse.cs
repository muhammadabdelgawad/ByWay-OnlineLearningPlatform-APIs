namespace ByWay.Application.Abstraction.DTOs.Cart
{
    public class CartResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public IEnumerable<CartItemResponse> Items { get; set; } = new List<CartItemResponse>();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}

