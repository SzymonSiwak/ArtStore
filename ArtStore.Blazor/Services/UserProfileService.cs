using System.Net.Http.Json;
using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Services
{
	public class UserProfileService
	{
		private readonly HttpClient _http;

		public HashSet<Guid> FavoriteProductIds { get; private set; } = new();
		public event Action? OnChange; 

		public UserProfileService(HttpClient http) => _http = http;

		public async Task<UserProfileDto?> GetProfile()
		{
			var profile = await _http.GetFromJsonAsync<UserProfileDto>("api/profile");
			if (profile != null)
			{
				FavoriteProductIds = profile.Favorites.Select(p => p.Id).ToHashSet();
				OnChange?.Invoke();
			}
			return profile;
		}

		public async Task ToggleFavorite(Guid productId)
		{
			var response = await _http.PostAsync($"api/profile/favorites/{productId}", null);
			if (response.IsSuccessStatusCode)
			{
				if (FavoriteProductIds.Contains(productId))
					FavoriteProductIds.Remove(productId);
				else
					FavoriteProductIds.Add(productId);

				OnChange?.Invoke();
			}
		}

		public bool IsFavorite(Guid productId) => FavoriteProductIds.Contains(productId);
	}
}
