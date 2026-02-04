using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Products.Queries.GetFilteredProducts
{
    public record GetFilteredProductsQuery(ProductFilterDto filter) : IRequest<IEnumerable<ProductDto>>;

	public class GetFilteredProductsQueryHandler : IRequestHandler<GetFilteredProductsQuery, IEnumerable<ProductDto>>
	{
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetFilteredProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
			_mapper = mapper;
		}

        public async Task<IEnumerable<ProductDto>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetFilteredProductsAsync(request.filter);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
		}

	}
}
