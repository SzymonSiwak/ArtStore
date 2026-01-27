using System.Net.Http;
using System.Net.Http.Json;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTOs;

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

		public async Task<ArtistDetailsDto?> GetArtistById(Guid id)
		{
			try
			{
				return await _http.GetFromJsonAsync<ArtistDetailsDto>($"api/artist/{id}");
			}
			catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}
		}
	}
}
