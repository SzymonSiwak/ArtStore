using ArtStore.Shared.DTOs;

namespace ArtStore.Blazor.Interfaces
{
    public interface IProductService
    {
		Task<HomePageDto?> GetHomePageData();
		Task<ProductDto?> GetProductById(Guid id);

	}
}
