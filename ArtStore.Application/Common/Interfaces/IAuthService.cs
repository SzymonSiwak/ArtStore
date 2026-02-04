using ArtStore.Shared.DTO;

namespace ArtStore.Application.Common.Interfaces
{
	public interface IAuthService
	{
		Task<AuthResponseDto> LoginAsync(LoginDto request);
		Task<string> RegisterAsync(RegisterDto request); 
	}
}