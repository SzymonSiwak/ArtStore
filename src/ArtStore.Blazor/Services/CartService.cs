using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;
using Microsoft.JSInterop;

namespace ArtStore.Blazor.Services
{
    public class CartService : ICartService
	{
        private readonly HttpClient _http;
        private readonly IAuthService _auth;
        private readonly IJSRuntime _jsRuntime;

        public CartService(HttpClient http, IAuthService auth, IJSRuntime jsRuntime)
        {
            _http = http;
            _auth = auth;
			_jsRuntime = jsRuntime;
		}

        public async Task AddToCart(Guid productId, int quantity)
        {
            var token = await _auth.GetToken();

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("You must be logged in to add items to cart.");
            }

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new { ProductId = productId, Quantity = quantity };

            var response = await _http.PostAsJsonAsync("api/cart/add", request);

			if (!response.IsSuccessStatusCode)
			{
				throw new Exception("Failed to add to cart.");
			}
		}

		public async Task RemoveFromCart(Guid productId)
		{
			var token = await _auth.GetToken();
			_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var response = await _http.DeleteAsync($"api/cart/items/{productId}");

			if (!response.IsSuccessStatusCode)
			{
				throw new Exception("Failed to remove item.");
			}
		}

		public async Task<CartDto?> GetCart()
        {
            var token = await _auth.GetToken();
            if (string.IsNullOrEmpty(token)) return null;

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                return await _http.GetFromJsonAsync<CartDto>("api/cart");
			}
            catch(Exception ex)
            {
                return null;
            }
		}

		public async Task<bool> TryAddToCartAsync(Guid productId, int quantity = 1)
        {
			try
			{
				await AddToCart(productId, quantity);
				return true;
			}
			catch (Exception ex) when (ex.Message.Contains("logged in") || ex.Message.Contains("401"))
			{

				// Save intention to local storage
				var intent = new { ProductId = productId, Quantity = quantity };
				var jsonIntent = JsonSerializer.Serialize(intent);
				await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "pendingCartItem", jsonIntent);

				return false; 
			}
		}
	}
}
