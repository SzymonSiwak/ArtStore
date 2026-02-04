using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Cart.Commands
{
    public record RemoveFromCartCommand(string UserId, Guid ProductId) : IRequest<CartDto>;
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public RemoveFromCartCommandHandler(ICartRepository cartRepository,
                                            IProductRepository productRepository,
                                            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByUserIdAsync(request.UserId);

            if (cart == null)
            {
                return new CartDto();
            }

            cart.RemoveItem(request.ProductId);
            await _cartRepository.SaveChangesAsync();

            return _mapper.Map<CartDto>(cart);
        }
    }
}
