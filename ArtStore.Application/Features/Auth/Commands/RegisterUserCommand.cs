using ArtStore.Application.Common.Interfaces;
using ArtStore.Application.DTOs;
using MediatR;

namespace ArtStore.Application.Features.Auth.Commands
{
	public record RegisterUserCommand(RegisterDto Dto) : IRequest<string>;

	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
	{
		private readonly IAuthService _authService;

		public RegisterUserCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			return await _authService.RegisterAsync(request.Dto);
		}
	}
}