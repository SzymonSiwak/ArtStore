namespace ArtStore.Shared.DTOs
{
	public class ArtistDetailsDto : ArtistDto
	{
		public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
	}
}
