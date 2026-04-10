namespace ArtStore.Shared.DTO
{
	public class ArtistDetailsDto : ArtistDto
	{
		public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
	}
}
