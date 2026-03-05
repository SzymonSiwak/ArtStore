using System.Security.Claims;
using ArtStore.Application.Features.User.Commands.ToogleFavorite;
using ArtStore.Application.Features.User.Queries.GetUserProfile;
using ArtStore.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProfileController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProfileController(IMediator mediator)
		{
			_mediator = mediator;
		}

		private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

		[HttpGet]
		public async Task<ActionResult<UserProfileDto>> GetProfile()
		{
			return Ok(await _mediator.Send(new GetUserProfileQuery(GetUserId())));
		}

		[HttpPost("favorites/{productId}")]
		public async Task<ActionResult<bool>> ToggleFavorite(Guid productId)
		{
			var result = await _mediator.Send(new ToggleFavoriteCommand(GetUserId(), productId));
			return Ok(result);
		}
	}
}
