using System.Security.Claims;
using ArtStore.Shared.DTOs;
using ArtStore.Application.Features.Cart.Commands;
using ArtStore.Application.Features.Cart.Queries.GetCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Helper method to get the user ID from the claims
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var userId = GetUserId();
            var result = await _mediator.Send(new GetCartQuery(userId));
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CartDto>> AddToCart([FromBody] AddToCartRequest request)
        {
            var userId = GetUserId();
            var command = new AddToCartCommand(userId, request.ProductId, request.Quantity);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

		[HttpDelete("items/{productId}")]
		public async Task<ActionResult<CartDto>> RemoveItem(Guid productId)
		{
			var userId = GetUserId();
			var command = new RemoveFromCartCommand(userId, productId);

			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}

	//Helper method to represent the add to cart request body
	public class AddToCartRequest
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
