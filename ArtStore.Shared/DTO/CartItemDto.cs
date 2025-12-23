namespace ArtStore.Shared.DTOs
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
	}
}
