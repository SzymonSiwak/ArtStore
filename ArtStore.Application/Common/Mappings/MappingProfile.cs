using ArtStore.Application.DTO;
using ArtStore.Domain.Entities;
using AutoMapper;

namespace ArtStore.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Price.Currency))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist != null ? 
                           src.Artist.Name : string.Empty));
		}
	}
}
