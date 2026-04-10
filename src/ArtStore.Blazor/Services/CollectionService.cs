using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;
using System.Net.Http.Json;

namespace ArtStore.Blazor.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly HttpClient _http;
        private List<CollectionDto>? _cachedCollections;
        public CollectionService(HttpClient http) => _http = http;

        public async Task<IEnumerable<CollectionDto>> GetAllCollectionsAsync()
        {
            try
            {
                _cachedCollections = await _http.GetFromJsonAsync<List<CollectionDto>>("api/Collections");
                return _cachedCollections ?? new List<CollectionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd pobierania kolekcji: {ex.Message}");
                return new List<CollectionDto>();
            }
        }
    }
}
