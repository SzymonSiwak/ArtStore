using ArtStore.Application.Features.Artist.Queries;
using ArtStore.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDto>>> GetArtists()
        {
            var artists = await _mediator.Send(new GetArtistsQuery());
            return Ok(artists);
		}
	}
}
