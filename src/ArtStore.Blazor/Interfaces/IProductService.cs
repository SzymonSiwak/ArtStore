using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface IProductService
    {
		Task<HomePageDto?> GetHomePageData();
		Task<ProductDto?> GetProductById(Guid id);
		Task<IEnumerable<ProductDto>> GetFilteredProducts(ProductFilterDto filter);
	}
}
