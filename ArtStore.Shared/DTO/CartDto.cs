namespace ArtStore.Shared.DTO
{
    public class CartDto
    {
        public Guid UserId { get; set; }
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public decimal TotalAmount { get; set; }
	}
}
