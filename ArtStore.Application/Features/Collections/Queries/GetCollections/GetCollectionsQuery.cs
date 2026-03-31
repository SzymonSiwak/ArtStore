using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Collections.Queries.GetCollections
{
    public record GetCollectionsQuery : IRequest<IEnumerable<CollectionDto>>;

    public class GetCollectionsQueryHandler : IRequestHandler<GetCollectionsQuery, IEnumerable<CollectionDto>>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public GetCollectionsQueryHandler(ICollectionRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CollectionDto>> Handle(GetCollectionsQuery request, CancellationToken cancellationToken)
        {
            var collections = await _collectionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CollectionDto>>(collections);
        }
    }
}
