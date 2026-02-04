using System.Net.Http.Json;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Services
{
    public class ProductService : IProductService
	{
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HomePageDto?> GetHomePageData()
        {
            return await _httpClient.GetFromJsonAsync<HomePageDto>("api/Product/home");
		}

        public async Task<ProductDto?> GetProductById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
		}

		public async Task<IEnumerable<ProductDto>> GetFilteredProducts(ProductFilterDto filter)
		{
			var response = await _httpClient.PostAsJsonAsync("api/products/search", filter);
			return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>() ?? new List<ProductDto>();
		}
	}
}
