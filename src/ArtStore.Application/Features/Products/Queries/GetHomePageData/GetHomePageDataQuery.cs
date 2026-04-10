using ArtStore.Shared.DTO;
using ArtStore.Shared.Enums;
using ArtStore.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Products.Queries.GetHomePageData
{
    public record GetHomePageDataQuery : IRequest<HomePageDto>;

	public class GetHomePageDataQueryHandler : IRequestHandler<GetHomePageDataQuery, HomePageDto>
	{
        private readonly IProductRepository _productRepository;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public GetHomePageDataQueryHandler(IProductRepository productRepository, ICollectionRepository collectionRepository ,IMapper mapper)
		{ 	
			_productRepository = productRepository;
			_collectionRepository = collectionRepository;
			_mapper = mapper;
		}

		public async Task<HomePageDto> Handle(GetHomePageDataQuery request, CancellationToken cancellationToken)
		{
			var collections = await _collectionRepository.GetAllAsync();
            var newArrivals = await _productRepository.GetNewArrivalsAsync(4);

			//Mapping to DTOs and returning
			var homePageDto = new HomePageDto
			{
				NewArrivals = _mapper.Map<IEnumerable<ProductDto>>(newArrivals),
				FeaturedCollections = _mapper.Map<IEnumerable<CollectionDto>>(collections)
			};
			return homePageDto;
		}
	}
}
