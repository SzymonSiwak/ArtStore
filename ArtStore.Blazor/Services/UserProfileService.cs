using System.Net.Http.Headers;
using System.Net.Http.Json;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Services
{
	public class UserProfileService : IUserProfileService
	{
		private readonly HttpClient _http;
        private readonly IAuthService _auth;

        public HashSet<Guid> FavoriteProductIds { get; private set; } = new();
		public event Action? OnChange;

		public UserProfileService(HttpClient http, IAuthService auth)
		{
			_http = http;
			_auth = auth;
		}

		public async Task<UserProfileDto?> GetProfile()
		{
			var token = await _auth.GetToken();

			if (!string.IsNullOrEmpty(token))
			{
				_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}

			try
			{
				var profile = await _http.GetFromJsonAsync<UserProfileDto>("api/profile");
				if (profile != null)
				{
					FavoriteProductIds = profile.Favorites.Select(p => p.Id).ToHashSet();
					OnChange?.Invoke();
				}
				return profile;
			}
			catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				return null;
			}
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
			else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				// Throwing this exception will be caught in the UI layer, where we can redirect to login or show a message
				throw new Exception("401");
			}
			else
			{
				throw new Exception("Failed to toggle favorite.");
			}
		}

		public bool IsFavorite(Guid productId) => FavoriteProductIds.Contains(productId);
	}
}
