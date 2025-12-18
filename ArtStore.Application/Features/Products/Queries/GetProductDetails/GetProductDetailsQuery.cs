using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Application.DTO;
using ArtStore.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Products.Queries.GetProductDetails
{
	public record GetProductDetailsQuery(Guid Id) : IRequest<ProductDto>;
	public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
		}

        public async Task<ProductDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
			}

            return _mapper.Map<ProductDto>(product);
		}
    }
}
