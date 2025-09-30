namespace ByWay.Domain.Entities.Cart
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public required IEnumerable<CartItem> Items { get; set; }= new List<CartItem>();



    }
}
