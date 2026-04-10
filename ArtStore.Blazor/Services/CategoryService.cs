using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;
using System.Net.Http.Json;

namespace ArtStore.Blazor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/Category")
                       ?? new List<CategoryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd pobierania kategorii: {ex.Message}");
                return new List<CategoryDto>();
            }
        }
    }
}