using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface IAuthService
    {
		Task<string?> Register(RegisterDto register);
		Task<(bool Success, string? ErrorMessage)> Login(LoginDto login);
		Task Logout();
		Task<string> GetToken();
	}
}
