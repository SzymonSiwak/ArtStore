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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICollectionRepository _collectionRepository;

        public GetFilteredProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, ICollectionRepository collectionRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _collectionRepository = collectionRepository;
            _mapper = mapper;
		}

        public async Task<IEnumerable<ProductDto>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            var filter = request.filter;

            // Translate slugs to IDs 
            if (!string.IsNullOrEmpty(filter.CollectionSlug))
            {
                var collection = await _collectionRepository.GetBySlugAsync(filter.CollectionSlug);
                if (collection != null)
                {
                    filter.CollectionId = collection.Id;
                }
            }

            // Translate category slug to IDs
            if (!string.IsNullOrEmpty(filter.CategorySlug))
            {
                var category = await _categoryRepository.GetBySlugAsync(filter.CategorySlug);
                if (category != null)
                {
                    filter.CategoryId = category.Id;
                }
            }

            var products = await _productRepository.GetFilteredProductsAsync(filter);

            return _mapper.Map<IEnumerable<ProductDto>>(products);
		}

	}
}
