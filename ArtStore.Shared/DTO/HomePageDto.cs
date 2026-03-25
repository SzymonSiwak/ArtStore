using ArtStore.Shared.DTO;

namespace ArtStore.Shared.DTO
{
    public class HomePageDto
    {
		public IEnumerable<ProductDto> NewArrivals { get; set; } = new List<ProductDto>();
        public IEnumerable<CollectionDto> FeaturedCollections { get; set; } = new List<CollectionDto>();
    }
}
