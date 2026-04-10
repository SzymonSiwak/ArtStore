using ArtStore.Application.Features.Categories.Queries.GetCategories;
using ArtStore.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }
    }
}