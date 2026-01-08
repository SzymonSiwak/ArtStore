using ArtStore.Blazor.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ArtStore.Blazor.Services
{
    public class CartService : ICartService
	{
        private readonly HttpClient _http;
        private readonly IAuthService _auth;

        public CartService(HttpClient http, IAuthService auth)
        {
            _http = http;
            _auth = auth;
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
    }
}
