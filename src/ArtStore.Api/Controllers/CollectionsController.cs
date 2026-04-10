using ArtStore.Application.Features.Collections.Queries.GetCollections;
using ArtStore.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CollectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetCollectionsQuery());
            return Ok(result);
        }
    }
}