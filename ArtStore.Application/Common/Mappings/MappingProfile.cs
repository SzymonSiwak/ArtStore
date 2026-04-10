using ArtStore.Shared.DTO;
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
                           src.Artist.Name : string.Empty))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? 
                           src.Category.Name : "Uncategorized"))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category != null ? 
                           src.Category.Id : Guid.Empty));

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product!.ImageUrl))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product!.Price.Amount))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => 
                           src.Product!.Price.Amount * src.Quantity));

            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => 
                           src.Items.Sum(i => i.Product!.Price.Amount * i.Quantity)));

			CreateMap<Artist, ArtistDto>();

			CreateMap<Artist, ArtistDetailsDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Collection, CollectionDto>();

            CreateMap<User, UserProfileDto>();
		}
	}
}
