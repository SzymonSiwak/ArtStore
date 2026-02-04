using ArtStore.Shared.DTO;

namespace ArtStore.Blazor.Interfaces
{
    public interface IAuthService
    {
		Task<bool> Login(LoginDto loginModel);
		Task Logout();
		Task<string> GetToken();
	}
}
