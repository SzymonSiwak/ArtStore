using ArtStore.Application.Features.Products.Queries.GetHomePageData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
		}

        [HttpGet("home")]
        public async Task<ActionResult<HomePageDto>> GetHomePageData()
        {
            var result = await _mediator.Send(new GetHomePageDataQuery());
            return Ok(result);
		}
	}
}
