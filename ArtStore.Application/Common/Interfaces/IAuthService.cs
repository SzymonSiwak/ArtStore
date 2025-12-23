using ArtStore.Shared.DTOs;

namespace ArtStore.Application.Common.Interfaces
{
	public interface IAuthService
	{
		Task<AuthResponseDto> LoginAsync(LoginDto request);
		Task<string> RegisterAsync(RegisterDto request); 
	}
}