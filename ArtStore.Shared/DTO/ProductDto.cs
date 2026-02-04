namespace ArtStore.Shared.DTO
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; } // Money.Amount
		public string Currency { get; set; } = string.Empty; // Money.Currency
		public string ImageUrl { get; set; } = string.Empty;
		public string ArtistName { get; set; } = string.Empty;
	}
}
