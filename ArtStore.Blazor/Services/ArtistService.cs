using System.Net.Http.Json;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Services
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient _http;

        public ArtistService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<ArtistDto>> GetAllArtists()
        {
            try
            {
                return await _http.GetFromJsonAsync<IEnumerable<ArtistDto>>("api/artist")
                    ?? new List<ArtistDto>();
            }
            catch
            {
                return new List<ArtistDto>();
            }

        }
    }
}
