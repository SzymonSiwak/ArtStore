using Microsoft.JSInterop;
using ArtStore.Blazor.Interfaces;
using ArtStore.Shared.DTO;
using System.Net.Http.Json;

namespace ArtStore.Blazor.Services
{
    public class AuthService : IAuthService
	{
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;


		public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
		}

        public async Task<string?> Register(RegisterDto register)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", register);
            if (response.IsSuccessStatusCode)
            {
                return null; // Registration successful, no error message
			}
			var errorContent = await response.Content.ReadAsStringAsync();
			return errorContent; 
        }

		public async Task<(bool Success, string? ErrorMessage)> Login(LoginDto login)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", login);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();

				// Store the token in local storage
				await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", result!.Token);

				return (true, null);
			}

            var errorMsg = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                errorMsg = "An error occurred during login. Please try again.";
            }

            return (false, errorMsg);
        }

        public async Task Logout()
        {
			// Remove the token from local storage
			await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");

			// Clear the default request headers to ensure the token is not sent with future requests
			_httpClient.DefaultRequestHeaders.Authorization = null;
		}

        public async Task<string> GetToken()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        }
    }
}
