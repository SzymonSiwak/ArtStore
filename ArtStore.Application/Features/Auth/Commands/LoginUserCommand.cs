using ArtStore.Application.Common.Interfaces;
using ArtStore.Application.DTOs;
using MediatR;

namespace ArtStore.Application.Features.Auth.Commands
{
	public record LoginUserCommand(LoginDto Dto) : IRequest<AuthResponseDto>;

	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseDto>
	{
		private readonly IAuthService _authService;

		public LoginUserCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
		{
			return await _authService.LoginAsync(request.Dto);
		}
	}
}