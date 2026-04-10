using ArtStore.Application.Common.Interfaces;
using ArtStore.Shared.DTO;
using ArtStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ArtStore.Infrastructure.Identity
{
    public class AuthService : IAuthService
	{
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
		}

        public async Task<AuthResponseDto> LoginAsync(LoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid username or password.");
            }

            var roles = await _userManager.GetRolesAsync(user);
			var token = _tokenService.GenerateToken(user.Id, user.Email, roles);


            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
				Token = token
            };
		}

        public async Task<string> RegisterAsync(RegisterDto request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed: {errors}");
			}

            return user.Id;
		}
	}
}
