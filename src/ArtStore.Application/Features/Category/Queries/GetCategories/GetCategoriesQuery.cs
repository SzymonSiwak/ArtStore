using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository; // Upewnij się, że masz to repozytorium!
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}