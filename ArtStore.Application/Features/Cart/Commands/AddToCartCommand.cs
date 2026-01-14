using ArtStore.Shared.DTOs;
using ArtStore.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Cart.Commands
{
    public record AddToCartCommand(string UserId, Guid ProductId, int Quantity) :  IRequest<CartDto>;
	public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddToCartCommandHandler(ICartRepository cartRepository, 
                                       IProductRepository productRepository,
                                       IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
		}

        public async Task<CartDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if(product == null) throw new Exception("Product not found");

            var cart = await _cartRepository.GetByUserIdAsync(request.UserId);
            if(cart == null)
            {
                cart = new Domain.Entities.Cart { UserId = request.UserId };
                await _cartRepository.AddAsync(cart);
			}

            cart.AddItem(request.ProductId, request.Quantity);
            await _cartRepository.SaveChangesAsync();

            return _mapper.Map<CartDto>(cart);
		}
    }
}
