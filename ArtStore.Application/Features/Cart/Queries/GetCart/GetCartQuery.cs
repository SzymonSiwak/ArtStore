using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Application.DTO;
using ArtStore.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Cart.Queries.GetCart
{
    public record GetCartQuery(string UserId) : IRequest<CartDto>;
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
	{
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByUserIdAsync(request.UserId);
            if (cart == null)
            {
                cart = new Domain.Entities.Cart { UserId = request.UserId };
                await _cartRepository.AddAsync(cart);
            }

			return _mapper.Map<CartDto>(cart);
		}      
    }
}
