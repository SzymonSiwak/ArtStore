using ArtStore.Shared.DTOs;

namespace ArtStore.Application.Features.Products.Queries.GetHomePageData
{
    public class HomePageDto
    {
        public IEnumerable<ProductDto> Bestsellers { get; set; } = new List<ProductDto>();
		public IEnumerable<ProductDto> NewArrivals { get; set; } = new List<ProductDto>();
		public IEnumerable<ProductDto> LivingSection { get; set; } = new List<ProductDto>();
		public IEnumerable<ProductDto> StationarySection { get; set; } = new List<ProductDto>();
	}
}
