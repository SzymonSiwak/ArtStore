using ArtStore.Shared.DTO;
using ArtStore.Application.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
		}

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterDto request)
        {
            try
            {
				var userId = await _mediator.Send(new RegisterUserCommand(request));
				return Ok(new { UserId = userId });
			}
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
			}
		}

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto request)
        {
            var result = await _mediator.Send(new LoginUserCommand(request));
            return Ok(result);
        }
	}
}
