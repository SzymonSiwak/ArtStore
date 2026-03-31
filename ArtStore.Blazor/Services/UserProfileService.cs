using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;
using Microsoft.JSInterop;

namespace ArtStore.Blazor.Services
{
	public class UserProfileService : IUserProfileService
	{
		private readonly HttpClient _http;
        private readonly IAuthService _auth;
        private readonly IJSRuntime _jsRuntime;

        public HashSet<Guid> FavoriteProductIds { get; private set; } = new();
		public event Action? OnChange;

		public UserProfileService(HttpClient http, IAuthService auth, IJSRuntime jsRuntime)
		{
			_http = http;
			_auth = auth;
			_jsRuntime = jsRuntime;
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
			var token = await _auth.GetToken();

			if (string.IsNullOrEmpty(token))
			{
				await SaveFavoriteIntentAsync(productId);
				throw new Exception("401");
			}

			_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var response = await _http.PostAsync($"api/profile/favorites/{productId}", null);
			if (response.IsSuccessStatusCode)
			{
				if (FavoriteProductIds.Contains(productId))
					FavoriteProductIds.Remove(productId);
				else
					FavoriteProductIds.Add(productId);

				OnChange?.Invoke();
			}
			else if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				// In case the token is invalid/expired, we should also save the intent to favorite the product
				await SaveFavoriteIntentAsync(productId);

				// Throwing this exception will be caught in the UI layer, where we can redirect to login or show a message
				throw new Exception("401");
			}
			else
			{
				throw new Exception("Failed to toggle favorite.");
			}
		}

        private async Task SaveFavoriteIntentAsync(Guid productId)
        {
            var intent = new { ProductId = productId };
            var jsonIntent = JsonSerializer.Serialize(intent);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "pendingFavoriteItem", jsonIntent);
        }

        public bool IsFavorite(Guid productId) => FavoriteProductIds.Contains(productId);
	}
}
