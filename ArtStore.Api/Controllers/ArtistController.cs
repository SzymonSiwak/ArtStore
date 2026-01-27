using ArtStore.Application.Features.Artist.Queries;
using ArtStore.Application.Features.Artists.Queries.GetArtistDetails;
using ArtStore.Shared.DTOs;
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

		[HttpGet("{id}")]
		public async Task<ActionResult<ArtistDetailsDto>> GetById(Guid id)
		{
			var query = new GetArtistDetailsQuery(id);
			var result = await _mediator.Send(query);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}
	}
}
