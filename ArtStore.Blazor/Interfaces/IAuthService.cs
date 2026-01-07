using ArtStore.Shared.DTOs;

namespace ArtStore.Blazor.Interfaces
{
    public interface IAuthService
    {
		Task<bool> Login(LoginDto loginModel);
		Task Logout();
		Task<string> GetToken();
	}
}
