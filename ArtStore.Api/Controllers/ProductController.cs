using ArtStore.Shared.DTOs;
using ArtStore.Application.Features.Products.Queries.GetHomePageData;
using ArtStore.Application.Features.Products.Queries.GetProductDetails;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductDetails(Guid id)
        {
            var result = await _mediator.Send(new GetProductDetailsQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
