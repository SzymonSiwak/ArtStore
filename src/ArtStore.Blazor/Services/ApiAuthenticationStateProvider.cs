using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using ArtStore.Blazor.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace ArtStore.Blazor.Services
{
	public class ApiAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly HttpClient _httpClient;
		private readonly IAuthService _authService;
		private readonly IUserProfileService _userService;

		public ApiAuthenticationStateProvider(HttpClient httpClient, IAuthService authService, IUserProfileService userService)
		{
			_httpClient = httpClient;
			_authService = authService;
			_userService = userService;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var token = await _authService.GetToken();

			if (string.IsNullOrWhiteSpace(token))
			{
				return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
			}

			// Adding the token to the default request headers so that it will be sent with every request
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

			return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
		}
		

		// Method to update the authentication state when the user logs in or out
		public void MarkUserAsAuthenticated(string email)
		{
			var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "jwt"));
			var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
			NotifyAuthenticationStateChanged(authState);
		}

		public void MarkUserAsLoggedOut()
		{
			var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
			var authState = Task.FromResult(new AuthenticationState(anonymousUser));
			NotifyAuthenticationStateChanged(authState);
		}

		// Helper method to parse claims from the JWT token
		private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
			return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
		}

		private byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2: base64 += "=="; break;
				case 3: base64 += "="; break;
			}
			return Convert.FromBase64String(base64);
		}
	}
}