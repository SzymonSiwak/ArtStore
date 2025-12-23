using ArtStore.Shared.DTOs;
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
        private readonly IMapper _mapper;

        public GetHomePageDataQueryHandler(IProductRepository productRepository, IMapper mapper)
		{ 	_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<HomePageDto> Handle(GetHomePageDataQuery request, CancellationToken cancellationToken)
		{
			//Getting date from reposytory
			var bestsellers = await _productRepository.GetBestsellersAsync(4);
			var newArrivals = await _productRepository.GetNewArrivalsAsync(4);
			var living = await _productRepository.GetByCategoryAsync(Category.Living_Accessories);
			var stationary = await _productRepository.GetByCategoryAsync(Category.Stationary);

			//Mapping to DTOs and returning
			var homePageDto = new HomePageDto
			{
				Bestsellers = _mapper.Map<IEnumerable<ProductDto>>(bestsellers),
				NewArrivals = _mapper.Map<IEnumerable<ProductDto>>(newArrivals),
				LivingSection = _mapper.Map<IEnumerable<ProductDto>>(living),
				StationarySection = _mapper.Map<IEnumerable<ProductDto>>(stationary)
			};
			return homePageDto;
		}
	}
}
